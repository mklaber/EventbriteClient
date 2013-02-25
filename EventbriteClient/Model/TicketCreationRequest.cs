using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace EventbriteClient.Model
{
    public class TicketCreationRequest : CreationRequest
    {
        public long EventId { get; set; }
        [JsonIgnore]
        public TicketType TicketType { get; set; }
        private int IsDonation { get { return this.TicketType == Model.TicketType.Donations ? 1 : 0; } }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? QuantityAvailable { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IncludeFee { get; set; }
        [JsonProperty("min")]
        public int MinimumTicketsPerOrder { get; set; }
        [JsonProperty("max")]
        public int MaximumTicketsPerOrder { get; set; }

        public override void AddToQuery(System.Collections.Specialized.NameValueCollection qry)
        {
            base.AddToQuery(qry);
            qry["event_id"] = this.EventId.ToString();
            qry["is_donation"] = this.IsDonation.ToString();
            qry["name"] = this.Name;
            qry["start_date"] = this.StartDate.ToString(JsonSerializationHelpers.ISO_8601_DATE_TIME_FORMAT_STRING);
            qry["end_date"] = this.EndDate.ToString(JsonSerializationHelpers.ISO_8601_DATE_TIME_FORMAT_STRING);
            if (!string.IsNullOrEmpty(this.Description)) qry["description"] = this.Description;
            if (this.Price.HasValue) qry["price"] = this.Price.Value.ToString("0.00");
            if (this.QuantityAvailable.HasValue) qry["quantity_available"] = this.QuantityAvailable.Value.ToString();
            qry["include_fee"] = (Convert.ToByte(this.IncludeFee)).ToString();
            qry["min"] = this.MinimumTicketsPerOrder.ToString();
            qry["max"] = this.MaximumTicketsPerOrder.ToString();
        }
    }
}
