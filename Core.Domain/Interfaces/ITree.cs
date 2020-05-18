using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Interfaces
{
    public interface ITree: IComponent
    {
        ICollection<IComponent> Children { get; set; }
    }
}
