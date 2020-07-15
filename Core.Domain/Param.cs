using Core.Domain.Interfaces;
using System;

namespace Core.Domain
{
    public class Param : IEntity
    {
        public int Id { get; set; }

        public Param(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
        public bool IsDelete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset Created { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset Modified { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Param Copy()
        {
            return (Param)this.MemberwiseClone();
        }
    }
}
