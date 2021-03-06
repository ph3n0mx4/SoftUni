﻿namespace Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get =>this.width;
            set
            {
                this.width = value;
            }
        }

        public int Height
        {
            get => this.height;
            set
            {
                this.height = value;
            }
        }

        public void Draw()
        {
            DrawLine(this.Width, '*', '*');
            for (int i = 1; i < this.Height - 1; ++i)
                DrawLine(this.Width, '*', ' ');
            DrawLine(this.Width, '*', '*');
        }
        private void DrawLine(int Width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < Width - 1; ++i)
                Console.Write(mid);
            Console.WriteLine(end);
        }
    }
}
