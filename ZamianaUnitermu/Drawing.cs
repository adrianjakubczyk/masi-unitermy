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

        public string CycleVariable { get; set; }
        public string CycleOperation { get; set; }
        public string EliminationA { get; set; }
        public string EliminationB { get; set; }
        public string EliminationCondition { get; set; }
        public string EliminationOperation { get; set; }

        public bool Exchanged { get; set; }

        public FontFamily FontFamily { get; set; }
        public int FontSize { get; set; }

        public DrawingVisual Visual { get; set; }

        public Drawing(double width, double height)
        {
            _width = width;
            _height = height;
            CycleVariable = "";
            CycleOperation = "";
            EliminationA = "";
            EliminationB = "";
            EliminationCondition = "";
            EliminationOperation = "";



            Visual = new DrawingVisual();

        }

        public void Update()
        {
            using (DrawingContext dc = Visual.RenderOpen())
            {

                ClearDrawingContext(dc);

                //double margin = FontSize/3;
                double margin = 50;
                double origin = margin + FontSize;
                double radiusX = FontSize * 2 / 3;
                double radiusY = (FontSize + 2) * 3 / 4;
                Pen pen = new Pen(Brushes.Black, FontSize / 6);
                string textCycle = CycleVariable + "  ";

                if (CycleVariable.Length > 0 && CycleOperation.Length > 0)
                {
                    dc.DrawEllipse(Brushes.White, pen, new Point(origin, origin), radiusX, radiusY);
                    dc.DrawLine(pen, new Point(origin + radiusX, origin - radiusY), new Point(origin - radiusX, origin + radiusY));
                    if (!Exchanged)
                    {
                        textCycle += CycleOperation;
                    }
                    dc.DrawText(GetFormattedText(textCycle), new Point(origin + radiusX * 2, origin - GetFormattedText(textCycle).Height / 2));

                }


                if (EliminationA.Length > 0 && EliminationB.Length > 0 && EliminationCondition.Length > 0 && EliminationOperation.Length > 0)
                {
                    double originX = origin - radiusX;
                    double originY = origin + radiusY * 4;
                    double verticalLineSize = FontSize / 3;
                    double innerMargin = verticalLineSize * 2;
                    string textElimination = EliminationA + EliminationOperation + " " + EliminationB + EliminationOperation + " " + EliminationCondition;
                    if (Exchanged)
                    {
                        originX = origin + radiusX * 3 + GetFormattedText(textCycle).Width;
                        //originY = origin - verticalLineSize*2 - GetFormattedText(textElimination).Height / 4;
                        originY = origin - GetFormattedText(textCycle).Height / 2;
                        textElimination += "_" + CycleVariable;
                    }
                    textElimination += " - ?";
                    FormattedText formattedTextElimination = GetFormattedText(textElimination);
                    dc.DrawLine(pen, new Point(originX, originY - formattedTextElimination.Height / 4), new Point(originX + formattedTextElimination.Width + innerMargin * 2, originY - formattedTextElimination.Height / 4));
                    dc.DrawLine(pen, new Point(originX, originY - formattedTextElimination.Height / 4 - verticalLineSize), new Point(originX, originY - formattedTextElimination.Height / 4 + verticalLineSize));
                    dc.DrawLine(pen, new Point(originX + formattedTextElimination.Width + innerMargin * 2, originY - formattedTextElimination.Height / 4 - verticalLineSize), new Point(originX + formattedTextElimination.Width + innerMargin * 2, originY - formattedTextElimination.Height / 4 + verticalLineSize));
                    dc.DrawText(formattedTextElimination, new Point(originX + innerMargin, originY));

                }

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
