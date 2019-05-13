using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.Layouts.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
