using LoggerEx.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.Layouts
{
    class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
