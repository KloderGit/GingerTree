using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Interfaces
{
    public interface IComponent<T>
    {
        void SetParent(T parent);
        T GetParent();
    }
}
