using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.Layouts.Contracts
{
    public interface ILayout
    {
        string Format { get; }
    }
}
