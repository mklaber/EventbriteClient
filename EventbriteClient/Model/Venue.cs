using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace EventbriteClient.Model
{
    public class VenuesWrapper
    {
        [JsonProperty("venues")]
        private IEnumerable<VenueWrapper> VenueWrappers { get; set; }
        [JsonIgnore]
        public IEnumerable<Venue> Venues { get { return this.VenueWrappers == null ? new List<Venue>() : this.VenueWrappers.Select(vw => vw.Venue); } }
    }
    public class VenueWrapper
    {
        public Venue Venue { get; set; }
    }
    public class Venue
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
    }
}
