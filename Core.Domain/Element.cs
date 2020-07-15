using Core.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Element : IEntity
    {
        public int Id { get; set; }
        public Guid Key { get; set; } = Guid.NewGuid();

        public Element(string title)
        {
            if(String.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));
            Title = title;
        }

        public string Title { get; set; }
        public ICollection<Param> Params { get; set; } = new List<Param>();
        public bool IsDelete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset Created { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset Modified { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}