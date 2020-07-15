using Core.Domain;
using Core.Domain.Interfaces;
using Database.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Database.Domain
{
    public class Map : ITree<Map>, IStoreItem
    {
        public int Id { get; set; }
        public int NodeId { get; set; }
        public virtual Node Node { get; set; }

        public int? ParentId { get; set; }
        public virtual Map Parent { get; set; }

        public int Order { get; set; }

        public virtual ICollection<Map> Children { get; set; } = new List<Map>();

        public virtual ICollection<Payload> Payloads { get; set; } = new List<Payload>();

        public bool IsActive { get; set; }
        public bool IsDraft { get; set; }
        public bool IsArchived { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
    }
}
