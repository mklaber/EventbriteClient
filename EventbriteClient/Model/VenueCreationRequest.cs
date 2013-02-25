using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventbriteClient.Model
{
    public class VenueCreationRequest : CreationRequest
    {
        //todo: validate required
        public long OrganizerId { get; set; }
        //todo: validate required
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        //todo: validate 2 characters if US address 
        public string State { get { return this.Region; } set { this.Region = value; } }
        public string PostalCode { get; set; }
        //todo: validate 2-letter country code, according to the ISO-3166-1 alpha-2 format.
        public string CountryCode { get; set; }
        public override void AddToQuery(System.Collections.Specialized.NameValueCollection qry)
        {
            base.AddToQuery(qry);
            qry["organizer_id"] = this.OrganizerId.ToString();
            qry["name"] = this.Name;
            qry["country_code"] = this.CountryCode;
            if (!string.IsNullOrEmpty(this.Address)) qry["address"] = this.Address;
            if (!string.IsNullOrEmpty(this.Address2)) qry["address_2"] = this.Address2;
            if (!string.IsNullOrEmpty(this.City)) qry["city"] = this.City;
            if (!string.IsNullOrEmpty(this.Region)) qry["region"] = this.Region;
            if (!string.IsNullOrEmpty(this.PostalCode)) qry["postal_code"] = this.PostalCode;
        }
    }
}
