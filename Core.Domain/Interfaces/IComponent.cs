using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Interfaces
{
    public interface IComponent
    {
        IComponent Parent { get; set; }
        int Order { get; set; }
    }
}
