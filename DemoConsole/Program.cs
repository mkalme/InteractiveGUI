using System;
using System.Windows.Forms;
using InteractiveGUI;

namespace DemoConsole {
    class Program {

        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Mock mock = new Mock();

            new InputFormCreator(mock).CreateForm().ShowDialog();
            new InputFormCreator(mock).CreateForm().ShowDialog();

            Console.ReadLine();
        }
    }
}
