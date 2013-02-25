using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace EventbriteClient.Model
{
    public enum EventStatus
    {
        Draft,
        Live,
        Started,
        Ended,
        Canceled
    }
    public class EventCreationRequest : CreationRequest
    {
        //todo: validate 255 characters max
        public string Title { get; set; }
        public string Description { get; set; }
        //todo: spit out as ISO 8601 format (e.g., “2007-12-31 23:59:59″).
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //todo: deal with Olson timezone name (e.g., “Europe/London,” “America/Los_Angeles,” “US/Pacific”)
        public string Timezone { get; set; }
        //todo: convert IsPrivate to privacy = 0 for private event, privacy = 1 for public event
        public bool IsPrivate { get; set; }
        //todo: validate 255 characters max
        public string PersonalizedUrl { get; set; }
        public int VenueId { get; set; }
        public int OrganizerId { get; set; }
        public int Capacity { get; set; }
        //todo: validate ISO 4217 (e.g., "USD", "EUR")
        public string Currency { get; set; }
        public EventStatus Status { get; set; }
        [JsonProperty("google-analytics")]
        public string GoogleAnalyticsTrackerId { get; set; }
        public string CustomHeader { get; set; }
        public string CustomFooter { get; set; }
        public string ConfirmationPage { get; set; }
        public string ConfirmationEmail { get; set; }
        //todo: validate color is in the hexidecimal format FFFFFF without the bound
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
        public string LinkColor { get; set; }
        public string TitleTextColor { get; set; }
        public string BoxBackgroundColor { get; set; }
        public string BoxTextColor { get; set; }
        public string BoxBorderColor { get; set; }
        public string BoxHeaderBackgroundColor { get; set; }
        public string BoxHeaderTextColor { get; set; }

        public override void AddToQuery(System.Collections.Specialized.NameValueCollection qry)
        {
            base.AddToQuery(qry);
            qry["title"] = this.Title;
            if (!string.IsNullOrEmpty(this.Description)) qry["description"] = this.Description;
            qry["start_date"] = this.StartDate.ToString(JsonSerializationHelpers.ISO_8601_DATE_TIME_FORMAT_STRING);
            qry["end_date"] = this.EndDate.ToString(JsonSerializationHelpers.ISO_8601_DATE_TIME_FORMAT_STRING);
            //TODO: deal with timezone
            //qry["timezone"] = this.Timezone;
            qry["privacy"] = Convert.ToByte(!this.IsPrivate).ToString();
            if (!string.IsNullOrEmpty(this.PersonalizedUrl)) qry["personalized_url"] = this.PersonalizedUrl;
            qry["venue_id"] = this.VenueId.ToString();
            qry["organizer_id"] = this.OrganizerId.ToString();
            qry["capacity"] = this.Capacity.ToString();
            qry["currency"] = this.Currency.ToString();
            qry["status"] = this.Status.ToString().ToLower();
            /*
             * In linqpad:
             * 	foreach (string s in new string[] { "CustomHeader", "CustomFooter", "ConfirmationPage", "ConfirmationEmail", "BackgroundColor", "TextColor", "LinkColor", "TitleTextColor", "BoxBackgroundColor", "BoxTextColor", "BoxBorderColor", "BoxHeaderBackgroundColor", "BoxHeaderTextColor" })
             * 	{
             * 		string.Format(@"if (!string.IsNullOrEmptyString(this.{0})) qry[""{1}""] = this.{0};", s, System.Text.RegularExpressions.Regex.Replace(s, @"([A-Z])([A-Z][a-z])|([a-z0-9])([A-Z])", "$1$3_$2$4").ToLower()).Dump();
             * 	}
             * */
            if (!string.IsNullOrEmpty(this.GoogleAnalyticsTrackerId)) qry["google-analytics"] = this.GoogleAnalyticsTrackerId;
            if (!string.IsNullOrEmptyString(this.CustomHeader)) qry["custom_header"] = this.CustomHeader;
            if (!string.IsNullOrEmptyString(this.CustomFooter)) qry["custom_footer"] = this.CustomFooter;
            if (!string.IsNullOrEmptyString(this.ConfirmationPage)) qry["confirmation_page"] = this.ConfirmationPage;
            if (!string.IsNullOrEmptyString(this.ConfirmationEmail)) qry["confirmation_email"] = this.ConfirmationEmail;
            if (!string.IsNullOrEmptyString(this.BackgroundColor)) qry["background_color"] = this.BackgroundColor;
            if (!string.IsNullOrEmptyString(this.TextColor)) qry["text_color"] = this.TextColor;
            if (!string.IsNullOrEmptyString(this.LinkColor)) qry["link_color"] = this.LinkColor;
            if (!string.IsNullOrEmptyString(this.TitleTextColor)) qry["title_text_color"] = this.TitleTextColor;
            if (!string.IsNullOrEmptyString(this.BoxBackgroundColor)) qry["box_background_color"] = this.BoxBackgroundColor;
            if (!string.IsNullOrEmptyString(this.BoxTextColor)) qry["box_text_color"] = this.BoxTextColor;
            if (!string.IsNullOrEmptyString(this.BoxBorderColor)) qry["box_border_color"] = this.BoxBorderColor;
            if (!string.IsNullOrEmptyString(this.BoxHeaderBackgroundColor)) qry["box_header_background_color"] = this.BoxHeaderBackgroundColor;
            if (!string.IsNullOrEmptyString(this.BoxHeaderTextColor)) qry["box_header_text_color"] = this.BoxHeaderTextColor;
        }
    }
}
