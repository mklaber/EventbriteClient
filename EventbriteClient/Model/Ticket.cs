using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace EventbriteClient.Model
{
    public class TicketWrapper
    {
        [JsonProperty("ticket")]
        public Ticket Ticket { get; set; }
    }

    public enum TicketType
    {
        FixedPrice = 0,
        Donations = 1
    }
    public class Ticket
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //I suspect that a min or max of "0" really just means "null" ?
        public int Min { get; set; }

        public int Max { get; set; }
        public double? Price { get; set; } //null if type = donation
        public bool Visible { get; set; }
        public string Currency { get; set; }
        //0 for fixed-price tickets, 1 for donations.
        public TicketType Type { get; set; }
        public int? QuantityAvailable { get; set; }
        public int? QuantitySold { get; set; }
    }
}
