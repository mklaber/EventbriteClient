using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventbriteClient.Model
{
    public class OrganizerWrapper
    {
        public Organizer Organizer { get; set; }
    }
    public class Organizer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
    }
}
