using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schedule.Domain
{
    public class Schedule
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public ICollection<ScheduleElement> Items { get; set; }
        public ICollection<Param> Params { get; set; }


        public Node BasedOn { get; set; }

        public static Schedule Create(Node structure)
        {
            var sr = new Schedule();
            sr.Title = structure.GetEvent().Title;
            sr.Params = structure.GetParams().ToList();
            sr.BasedOn = structure;
            
            List<Element> el = new List<Element>();

            el = Get(structure).ToList();

            var date = DateTime.Today;

            sr.Items = el.Select(x => new ScheduleElement {
                 Date = date, Element = x, Params = x.Params
            }).ToList();

            IEnumerable<Element> Get (Node structure1)
            {
                if (structure1.GetChildren().Count() > 0)
                    return structure1.GetChildren().SelectMany(x => Get(x));


                return new List<Element>() { structure1.GetEvent() };
            }


            return sr;
        }
    }
}
