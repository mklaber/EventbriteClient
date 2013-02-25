using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace EventbriteClient.Model
{
    public class EventWrapper
    {
        [JsonProperty("event")]
        public Event Event { get; set; }
    }
    
    public class Event
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //Olson timezone name
        public string Timezone { get; set; }
        [JsonIgnore]
        public TimeZoneInfo TimezoneInfo { get { return JsonSerializationHelpers.OlsonTimeZoneToTimeZoneInfo(this.Timezone); } }
        public string TimezoneOffset { get; set; }
        public Organizer Organizer { get; set; }
        public string Category { get; set; }
        public string Tags { get; set; }
        public int? Capacity { get; set; }
        public int? NumAttendeeRows { get; set; }
        public EventStatus? Status { get; set; }
        [JsonProperty("tickets")]
        private IEnumerable<TicketWrapper> TicketWrappers { get; set; }
        [JsonIgnore]
        public IEnumerable<Ticket> Tickets { get { return this.TicketWrappers == new List<Ticket>() ? null : this.TicketWrappers.Select(tw => tw.Ticket); } }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string Url { get; set; }
        //todo: make privacy an enum?
        public string Privacy { get; set; }
        public string Repeats { get; set; }
        public Venue Venue { get; set; }
    }
}
