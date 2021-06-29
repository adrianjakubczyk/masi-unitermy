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

                dc.DrawLine(new Pen(Brushes.Blue, 10), new Point(), new Point(5000, 1000));

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
