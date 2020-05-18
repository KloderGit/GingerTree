using Core.Domain.Interfaces;

namespace Core.Domain
{
    public class Element : Base, ILeaf
    {
        public IComponent Parent { get; set; }
        public int Order { get; set; }
    }
}