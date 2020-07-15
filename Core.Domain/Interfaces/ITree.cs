using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Interfaces
{
    public interface ITree<T>: IComponent<T>
    {
        IEnumerable<T> GetChildren();
        void AddChild(T child);
    }
}
