using Core.Domain;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Schedule.Domain
{
    public class ScheduleElement
    {
        public Element Element { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Param> Params { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}