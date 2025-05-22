using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace InteractiveGUI {
    public class TypeIconCreator : ITypeIconCreator {
        private static IDictionary<Type, Image> _iconCollection = new Dictionary<Type, Image>() {
            {typeof(DateTime), IconResources.GetIcon("InteractiveGUI.Resources.DataTypeIcons.Calendar_16x.png") },
            {typeof(Color), IconResources.GetIcon("InteractiveGUI.Resources.DataTypeIcons.ColorWheel_16x.png") },
            {typeof(Size),  IconResources.GetIcon("InteractiveGUI.Resources.DataTypeIcons.Size_16x.png")},
            {typeof(SizeF),  IconResources.GetIcon("InteractiveGUI.Resources.DataTypeIcons.Size_16x.png")},
            {typeof(Font), IconResources.GetIcon("InteractiveGUI.Resources.DataTypeIcons.Font_16x.png") },
            {typeof(Image), IconResources.GetIcon("InteractiveGUI.Resources.DataTypeIcons.Image_16x.png") },
            {typeof(Bitmap), IconResources.GetIcon("InteractiveGUI.Resources.DataTypeIcons.Image_16x.png") }
        };
        private static IDictionary<Type, string> _textIconCollection = new Dictionary<Type, string>() {
            { typeof(byte), "B" },
            { typeof(sbyte), "sB" },
            { typeof(ushort), "123" },
            { typeof(short), "123" },
            { typeof(uint), "123" },
            { typeof(int), "123" },
            { typeof(ulong), "123" },
            { typeof(long), "123" },
            { typeof(float), ".00" },
            { typeof(double), ".00" },
            { typeof(decimal), ".00" },
            { typeof(string), "abc" },
            { typeof(char), "a" },
            { typeof(bool), "T/F" }
        };
        private static IDictionary<Type, string> _borderlessTextIconCollection = new Dictionary<Type, string>() {
            {typeof(Point), "X;Y" },
            {typeof(PointF), "X;Y" }
        };
        private static IDictionary<Type, string> _otherCollection = new Dictionary<Type, string>() {
            { typeof(Array), "{}" },
            { typeof(Enum), "Enu" },
            { typeof(ValueType), "Val" },
            { typeof(object), "Obj" },
        };

        public Font Font { get; set; } = new Font("Calibri", 10, FontStyle.Bold);
        public Size Size { get; set; } = new Size(25, 25);

        public Image CreateIcon(Type type) {
            if (_iconCollection.TryGetValue(type, out Image image)) return ResizeImage(image, 17, 17);
            Color color = TypeColorController.GetColor(type);
            
            if (_textIconCollection.TryGetValue(type, out string text)) return CreateImage(text, color);
            if(_borderlessTextIconCollection.TryGetValue(type, out string bText)) return CreateImage(bText, color, Color.Transparent);

            if (type.IsArray) return CreateImage(_otherCollection[typeof(Array)], TypeColorController.GetColor(type.GetElementType()), Color.Transparent);
            if (type.IsEnum) return CreateImage(_otherCollection[typeof(Enum)], color, Color.Transparent);
            if (type.IsInterface) return CreateImage("I", color, Color.Transparent);
            if (type.IsValueType) return CreateImage(_otherCollection[typeof(ValueType)], color, Color.Transparent);

            return CreateImage(_otherCollection[typeof(object)], color, Color.Transparent);
        }

        private Bitmap CreateImage(string text, Color color) {
            return CreateImage(text, color, color);
        }
        private Bitmap CreateImage(string text, Color textColor, Color rectangleColor) {
            Bitmap output = new Bitmap(Size.Width, Size.Height);

            using (var graphics = Graphics.FromImage(output)) {
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                SizeF textSize = graphics.MeasureString(text, Font);

                int x = (int)Math.Round((Size.Width - textSize.Width) / 2F);
                int y = (int)Math.Round((Size.Height - (textSize.Height - 2)) / 2F) - 1;

                graphics.DrawString(text, Font, new SolidBrush(textColor), new Point(x, y));
                graphics.DrawRectangle(new Pen(rectangleColor), 0, 0, Size.Width - 1, Size.Height - 1);
            }

            return output;
        }

        private static Bitmap ResizeImage(Image image, int width, int height) {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage)) {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes()) {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
