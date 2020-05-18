using Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public abstract class Base
    {
        public int Id { get; set; }
        public Guid Key { get; set; }

        public string Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsDraft { get; set; }
    }
}
