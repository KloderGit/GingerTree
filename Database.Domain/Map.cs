﻿using System;
using System.Collections.Generic;

namespace Database.Domain
{
    public class Map
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }
        public virtual Map Parent { get; set; }

        public int Order { get; set; }

        public virtual ICollection<Map> Children { get; set; }

        public int NodeId { get; set; }
        public virtual Node Node { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
    }
}