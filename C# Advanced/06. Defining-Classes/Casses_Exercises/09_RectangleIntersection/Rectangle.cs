namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Rectangle
    {
        public Rectangle(string id, double width, double height, double x, double y)
        {
            Id = id;
            Width = width;
            Height = height;
            X = x;
            Y = y;
        }
        //id, width, height and the coordinates of its top left corner (horizontal and vertical)
        public string Id { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double X { get; set; }

        public double Y { get;set; }

        public bool Checkdoubleersect(Rectangle rectangle)
        {
            bool result = false;
            var l1x = rectangle.X;
            var r1x = rectangle.X + rectangle.Width;
            var l1y = rectangle.Y;
            var r1y = rectangle.Y - rectangle.Height;

            var l2x = X;
            var r2x = X + Width;
            var l2y = Y;
            var r2y = Y - Height;

            if(l1x<=r2x && l2x<=r1x && l1y>=r2y && l2y>=r1y)
            {
                result = true;
            }

            return result;
        }
    }
}
