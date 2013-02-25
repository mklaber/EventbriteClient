using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace EventbriteClient.Model
{
    public class AttendeesWrapper
    {
        [JsonProperty("attendees")]
        private IEnumerable<AttendeeWrapper> AttendeeWrappers { get; set; }
        [JsonIgnore]
        public IEnumerable<Attendee> Attendees { get { return this.AttendeeWrappers == null ? new List<Attendee>() : this.AttendeeWrappers.Select(aw => aw.Attendee); } }
    }
    public class AttendeeWrapper
    {
        public Attendee Attendee { get; set; }
    }

    public enum Gender
    {
        [EnumMember(Value = "M")]
        Male,
        [EnumMember(Value = "F")]
        Female
    }
    public class Attendee
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public long? TicketId { get; set; }
        public int? Quantity { get; set; }
        public string Currency { get; set; }
        public float? AmountPaid { get; set; }
        public string Barcode { get; set; }
        public int? OrderId { get; set; }
        public string OrderType { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime? EventDate { get; set; }
        public string Discount { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string HomeAddress { get; set; }
        public string HomeAddress2 { get; set; }
        public string HomeCity { get; set; }
        public string HomePostalCode { get; set; }
        public string HomeRegion { get; set; }
        public string HomeCountry { get; set; }
        public string HomeCountryCode { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string ShipAddress { get; set; }
        public string ShipAddress2 { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipRegion { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCountryCode { get; set; }
        public string WorkAddress { get; set; }
        public string WorkAddress2 { get; set; }
        public string WorkCity { get; set; }
        public string WorkPostalCode { get; set; }
        public string WorkRegion { get; set; }
        public string WorkCountry { get; set; }
        public string WorkCountryCode { get; set; }
        public string WorkPhone { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Website { get; set; }
        public string Blog { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Age { get; set; }
        [JsonProperty("answers")]
        private IEnumerable<AnswerWrapper> AnswerWrappers { get; set; }
        [JsonIgnore]
        public IEnumerable<Answer> Answers { get { return this.AnswerWrappers == null ? new List<Answer>() : this.AnswerWrappers.Select(aw => aw.Answer); } }
        [JsonProperty("barcodes")]
        private IEnumerable<BarcodeWrapper> BarcodeWrappers { get; set; }
        [JsonIgnore]
        public IEnumerable<Barcode> Barcodes { get { return this.BarcodeWrappers == null ? new List<Barcode>() : this.BarcodeWrappers.Select(bw => bw.Barcode); } }
    }
}
