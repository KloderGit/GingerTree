using Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Core.Domain
{
    public class Node : IEntity, ITree<Node>, IPayLoad
    {
        public Node() {}

        public Node(Element element)
        {
            Title = element.Title;
            this.element = element;
            this.@params = element.Params.Select(x => x.Copy()).ToList();
        }

        public int Id { get; set; } = new Random().Next(1, 10000);
        public Guid Key { get; set; } = Guid.NewGuid();

        public string Title { get; set; }
        public bool IsDelete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset Created { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset Modified { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private ICollection<Node> children = new List<Node>();
        public IEnumerable<Node> GetChildren()
        {
            return children;
        }
        public void AddChild(Node node)
        {
            var child = node.Clone();
            children.Add(child);
        }

        private ICollection<Param> @params = new List<Param>();
        public void AddParam(Param param)
        {
            @params.Add(param);
        }
        public IEnumerable<Param> GetParams()
        {
            return @params;
        }

        public Node Clone()
        {
            var cloneNode = new Node();
            cloneNode.Title = this.Title;
            cloneNode.SetEvent(this.GetEvent());
            cloneNode.@params = this.@params.Select(x => x.Copy()).ToList();

            if (this.GetChildren().Count() > 0)
            {
                cloneNode.children = this.children.Select(x => x.Clone()).ToList();
            }

            return cloneNode;
        }

        private Element element;
        public Element GetEvent()
        {
            return element;
        }

        public void SetEvent(Element element)
        {
            this.element = element;
        }

        private Node parent;
        public void SetParent(Node parent)
        {
            this.parent = parent;
        }

        public Node GetParent()
        {
            return parent;
        }

        public IEnumerable<Element> GetElements()
        {
            var res = new List<Element>();

            if (children.Count > 0)
            {
                res = children.SelectMany(x => x.GetElements()).ToList();
            }
            else
            {
                res.Add(element);
            }

            return res;
        }
    }

}
