using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace EventbriteClient.Model
{
    public class BarcodeWrapper
    {
        [JsonProperty("barcode")]
        public Barcode Barcode { get; set; }
    }
    public class Barcode
    {
        public long AttendeeId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Id { get; set; }
        //todo: is Status an enum?
        public string Status { get; set; }
    }
}
