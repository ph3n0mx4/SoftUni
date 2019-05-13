using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Ferrari
{
    public interface ICar
    {
        string DriversName { get; }
        string Model { get; }
        string Breaks();
        string Gas();
    }
}
