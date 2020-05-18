using System;

namespace Core.Domain
{
    public abstract class Base
    {
        public int Id { get; set; }
        public Guid Key { get; set; }

        public string Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsDraft { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
    }
}
