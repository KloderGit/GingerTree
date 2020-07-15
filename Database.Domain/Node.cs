using Core.Domain;
using Core.Domain.Interfaces;
using Database.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Database.Domain
{
    public class Node : IStoreItem
    {
        public int Id { get; set; }
        public Guid Key { get; set; }
        public bool IsActive { get; set; }
        public bool IsDraft { get; set; }
        public bool IsArchived { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Map> Maps { get; set; } = new List<Map>();
        public virtual ICollection<Payload> Payloads { get; set; } = new List<Payload>();

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
    }
}
