using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace InteractiveGUI {
    public partial class ObjectCreatorForm : Form {
        public ConstructorInfo[] Constructors { get; set; }
        public Type Type { get; set; }

        public ILayoutCreator LayoutCreator { get; set; } = new ParameterLayoutCreator();
        public IInputPanelCreator InputPanelCreator { get; set; } = new InputPanelCreator();
        public IObjectParser ObjectParser { get; set; } = new ObjectParser();

        public object Object { get; set; }

        public ObjectCreatorForm(ConstructorInfo[] constructors, Type type) {
            InitializeComponent();

            Constructors = constructors;
            Type = type;

            DisplayConstructorsInComboBox();
            Focus();

            if (constructors.Length > 0) ConstructorComboBox.SelectedIndex = 0;
        }

        private void DisplayConstructorsInComboBox() {
            ConstructorComboBox.Items.Clear();

            foreach (var constructor in Constructors) {
                ConstructorComboBox.Items.Add(CreateConstructorItem(constructor));
            }

            MethodInfo[] methods = GetAllUsableMethods(Type);
            foreach (var method in methods) {
                ConstructorComboBox.Items.Add(CreateMethodItem(method));
            }
        }
        private ConstructorItem CreateConstructorItem(ConstructorInfo constructor) {
            string text;

            ParameterInfo[] parameters = constructor.GetParameters();
            if (parameters.Length == 0) {
                text = "(No parameters)";
            } else {
                text = GetParameterString(parameters);
            }

            return new ConstructorItem(text) {
                Parameters = parameters,
                Invoker = (args) => Activator.CreateInstance(Type, args)
            };
        }
        private ConstructorItem CreateMethodItem(MethodInfo method) {
            string text;

            ParameterInfo[] parameters = method.GetParameters();
            text = $"(function) {method.Name}({GetParameterString(parameters)})";

            return new ConstructorItem(text) {
                Parameters = parameters,
                Invoker = (args) => method.Invoke(null, args)
            };
        }

        private static MethodInfo[] GetAllUsableMethods(Type type) {
            MethodInfo[] methods = type.GetMethods();

            List<MethodInfo> output = new List<MethodInfo>(methods.Length);
            foreach (var method in methods) {
                if (!method.IsStatic || !method.IsPublic) continue;
                if (method.ReturnType != type && !method.ReturnType.IsSubclassOf(type)) continue;

                output.Add(method);
            }

            return output.ToArray();
        }
        private static string GetParameterString(ParameterInfo[] parameters) {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < parameters.Length; i++) {
                var parameter = parameters[i];

                builder.Append(parameter.ParameterType.GetName());
                builder.Append(" ");
                builder.Append(parameter.Name);

                if (i < parameters.Length - 1) builder.Append(", ");
            }

            return builder.ToString();
        }

        private void ConstructorComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            ConstructorItem item = (ConstructorItem)ConstructorComboBox.SelectedItem;

            item.Layout = LayoutCreator.CreateLayout(item.Parameters);

            Panel panel = InputPanelCreator.CreatePanel(item.Layout);
            panel.Dock = DockStyle.Top;
            panel.Margin = new Padding(0);
            panel.AutoSize = true;

            GlobalContainer.Controls.Remove(GlobalContainer.GetControlFromPosition(0, 1));
            GlobalContainer.Controls.Add(panel, 0, 1);

            Height = panel.Height + 200;
        }

        private void DoneButton_Click(object sender, EventArgs e) {
            ConstructorItem item = (ConstructorItem)ConstructorComboBox.SelectedItem;

            if (item != null) {
                if (!ObjectParser.TryParse(item.Layout)) return;

                object[] arguments = new object[item.Parameters.Length];
                for (int i = 0; i < arguments.Length; i++) {
                    arguments[i] = item.Layout[i].GetValue();
                }

                Object = item.Invoker(arguments);
            } else {
                try {
                    Object = Activator.CreateInstance(Type);
                } catch { }
            }

            Close();
        }
    }
}
