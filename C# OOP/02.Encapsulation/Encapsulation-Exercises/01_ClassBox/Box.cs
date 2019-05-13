namespace _01_ClassBox
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box
    {
        public Box (double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double SurfaceArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height + 2 * this.Length * this.Width;
        }

        public double LateralSurfaceArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}
