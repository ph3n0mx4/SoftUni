namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        //public double Height
        //{
        //    get=>this.height;
        //    set
        //    {
        //        this.height = value;
        //    }
        //}

        //public double Width
        //{
        //    get => this.width;
        //    set
        //    {
        //        this.width = value;
        //    }
        //}

        public override double CalculateArea()
        {
            return this.height*this.width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.height + this.width);
        }

        public sealed override string Draw()
        {
            return base.Draw() + "Rectangle";
        }
    }
}
