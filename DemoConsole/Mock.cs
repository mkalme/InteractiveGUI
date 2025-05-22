using System;
using System.Drawing;
using InteractiveGUI;

namespace DemoConsole {
    public class Mock {
        [Interactive("Name of first")]
        public string FirstProperty { get; set; } = "None";

        [Interactive("Name of second")]
        public string SecondProperty { get; set; } = "Value";

        [Interactive, RangeValidator(0, 10)]
        public int Amount { get; set; }

        [Interactive]
        public decimal Change { get; set; }

        [Interactive]
        public DateTime Date { get; set; } = DateTime.Now;

        [Interactive, BrowserInput(BrowseType.Folder), PathValidator(BrowseType.Folder)]
        public string Folder { get; set; }

        [Interactive("Is open"), ComboBoxInput(true, false)]
        public bool IsOpen { get; set; } = true;

        [Interactive]
        public Color Color { get; set; } = Color.Wheat;

        [Interactive]
        public Months Month { get; set; } = (Months)(DateTime.Now.Month - 1);

        [Interactive("Edit object")]
        public Mock2 Mock2 { get; set; } = new Mock2();

        [Interactive, PropertyInput(ScaleType.Vertical, "Size", "Location")]
        public Rectangle Rectangle { get; set; } = new Rectangle();

        [Interactive]
        public int[] IntegerArray { get; set; } = new int[10];

        [Interactive, TextPropertyInput("Width", "Height")]
        public Size Point { get; set; }
    }

    public class Mock2 {
        [Interactive]
        public float Value { get; set; }

        [Interactive]
        public BrowseType Enum { get; set; }

        [Interactive]
        public Font Font { get; set; } = new Font("Microsoft Sans Serif", 10);

        [Interactive]
        public Mock3 Object { get; set; }

        [Interactive, ObjectInput]
        public string String { get; set; }

        [Interactive]
        public MockStruct MockStruct { get; set; }
    }

    public class Mock3 {
        [Interactive]
        public string Value { get; set; }

        [Interactive]
        public int Value1 { get; set; }

        [Interactive]
        public int Value2 { get; set; }

        public Mock3() {

        }
        public Mock3(string value) {
            Value = value;
        }
        public Mock3(int value1, int value2) {
            Value1 = value1;
            Value2 = value2;
        }
        public Mock3(string value, int value1, int value2) {
            Value = value;
            Value1 = value1;
            Value2 = value2;
        }

        public static Mock3 FromTest() => new Mock3();
        public static Mock3 FromTest(Image image) => new Mock3();
        public static Mock4 FromTest(string value1, int value2) => new Mock4();
    }

    public class Mock4 : Mock3 { 
    
    }

    public struct MockStruct {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }

    public enum Months { 
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        Spetember,
        October,
        November,
        December
    }
}
