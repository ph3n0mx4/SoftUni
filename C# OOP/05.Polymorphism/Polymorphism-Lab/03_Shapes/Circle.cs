namespace Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        //public double Radius
        //{
        //    get=>this.radius; 
        //    set
        //    {
        //        this.radius = value;
        //    }
        //}

        public override double CalculateArea()
        {
            return this.radius*this.radius*Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return 2*Math.PI*this.radius;
        }

        public sealed override string Draw()
        {
            return base.Draw() +"Circle";
        }
    }
}
