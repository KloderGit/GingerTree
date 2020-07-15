using Core.Domain.Interfaces;
using System;

namespace Database.Domain
{
    public class Payload : IStoreItem
    {
        public int Id { get; set; }
        public Guid Key { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Value { get; set; }

        public int? MapId { get; set; }
        public virtual Map Map { get; set; }

        public int NodeId { get; set; }
        public virtual Node Node { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsDraft { get; set; } = false;
        public bool IsArchived { get; set; } = false;
        public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset Modified { get; set; } = DateTimeOffset.Now;
    }
}
