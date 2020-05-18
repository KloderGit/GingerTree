using Core.Domain;
using System;
using System.Collections.Generic;

namespace Database.Domain
{
    public class Node : Base
    {
        public virtual ICollection<Map> Maps { get; set; }
    }
}
