﻿namespace _02_ClassBoxDataValidation
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                var box = new Box(length, width, height);
                double surfaceArea = box.SurfaceArea();
                double lateralSurfaceArea = box.LateralSurfaceArea();
                double volume = box.Volume();

                Console.WriteLine($"Surface Area - {surfaceArea:f2}");
                Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
                Console.WriteLine($"Volume - {volume:f2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }

}
