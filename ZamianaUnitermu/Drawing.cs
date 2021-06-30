using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ZamianaUnitermu
{
    class Drawing : UIElement
    {
        private double _width;
        private double _height;

        public String CycleVariable { get; set; }
        public String CycleOperation { get; set; }
        public String EliminationA { get; set; }
        public String EliminationB { get; set; }
        public String EliminationCondition { get; set; }
        public String EliminationOperation { get; set; }

        public bool Exchanged { get; set; }

        public FontFamily FontFamily { get; set; }
        public int FontSize { get; set; }

        public DrawingVisual Visual { get; set; }

        public Drawing(double width, double height)
        {
            _width = width;
            _height = height;

            Visual = new DrawingVisual();

        }

        public void Update()
        {
            using (DrawingContext dc = Visual.RenderOpen())
            {

                ClearDrawingContext(dc);

                double margin = FontSize/3;
                double origin = margin + FontSize;
                double radiusX = FontSize * 2 / 3;
                double radiusY = (FontSize + 2) * 3 / 4;
                Pen pen = new Pen(Brushes.Black, 2);
                dc.DrawEllipse(Brushes.White, pen, new Point(origin, origin), radiusX, radiusY);
                dc.DrawLine(pen, new Point(origin+radiusX,origin-radiusY), new Point(origin - radiusX, origin+radiusY));
                string text = CycleVariable + "  ";
                if (!Exchanged)
                {
                    text += CycleOperation;
                }
                dc.DrawText(GetFormattedText(CycleVariable+" "+CycleOperation), new Point(origin+radiusX+margin, origin/2));

                dc.Close();
            }
        }
        public void Clear()
        {
            using (DrawingContext dc = Visual.RenderOpen())
            {
                ClearDrawingContext(dc);
                dc.Close();
            }
        }
        private void ClearDrawingContext(DrawingContext dc)
        {
            dc.DrawRectangle(Brushes.White, new Pen(Brushes.White, 0), new Rect(new Size(_width, _height)));
        }

        private FormattedText GetFormattedText(string text)
        {
            Typeface typeface = new Typeface(FontFamily, FontStyles.Normal, FontWeights.Light, FontStretches.Medium);

            FormattedText formattedText = new FormattedText(text,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                typeface, FontSize, Brushes.Black, VisualTreeHelper.GetDpi(this).PixelsPerDip);

            formattedText.TextAlignment = TextAlignment.Left;

            return formattedText;
        }

        protected override int VisualChildrenCount
        {
            get { return Visual != null ? 1 : 0; }
        }

        protected override Visual GetVisualChild(int index)
        {
            return Visual;
        }
    }
}
