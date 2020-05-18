using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Interfaces
{
    public interface IComponent
    { 
    
    }

    public interface IComponent<T> : IComponent
    {
        T Parent { get; set; }
        int Order { get; set; }
    }
}
