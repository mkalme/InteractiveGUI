using System;
using System.Drawing;
using System.Windows.Forms;

namespace InteractiveGUI {
    class DatePanel : Panel {
        private DateTimePicker _datePicker = new DateTimePicker();
        private DateTimePicker _timePicker = new DateTimePicker();

        public DateTime SelectedeDateTime {
            get => _datePicker.Value.Date + _timePicker.Value.TimeOfDay;
            set {
                _datePicker.Value = value;
                _timePicker.Value = value;
            }
        }

        public DatePanel() {
            _datePicker.Format = DateTimePickerFormat.Custom;
            _datePicker.CustomFormat = "dd.MM.yyyy";
            _datePicker.Width = 80;
            _datePicker.Margin = new Padding(0);

            _timePicker.Format = DateTimePickerFormat.Time;
            _timePicker.ShowUpDown = true;
            _timePicker.Location = new Point(_datePicker.Width + 3, 0);
            _timePicker.Width = 80;
            _timePicker.Margin = new Padding(0);

            Controls.Add(_datePicker);
            Controls.Add(_timePicker);

            Margin = new Padding(0);
            Padding = new Padding(0);

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
