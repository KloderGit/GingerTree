using Core.Domain.Interfaces;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Module : Base, ITree<IComponent>
    {
        public IComponent Parent { get; set; }
        public int Order { get; set; }
        public ICollection<IComponent> Children { get; set; } = new List<IComponent>();
    }
}