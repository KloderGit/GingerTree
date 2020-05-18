using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Interfaces
{
    public interface ITree<T>: IComponent<T>
    {
        ICollection<T> Children { get; set; }
    }
}
