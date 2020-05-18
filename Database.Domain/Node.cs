using Core.Domain;
using System;

namespace Database.Domain
{
    public class Node : Base
    {
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
    }
}
