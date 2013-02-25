using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Formatting;
using EventbriteClient.Model;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EventbriteClient
{
    public class EventbriteClient : System.Net.Http.HttpClient
    {

        public EventbriteClient(string appKey, string userKey = null)
            : base(new EventbriteMessageHandler(new HttpClientHandler(), appKey, userKey))
        {
            BaseAddress = new Uri("http://www.eventbrite.com/json/");
        }



        protected T Get<T>(string method, string parameters)
        {
            HttpResponseMessage response = this.GetAsync(string.Format("{0}?{1}", method, parameters)).Result;
            response.EnsureSuccessStatusCode();
            //todo: handle error response
            /*
             * {
             *   "error": {
             *     "error_type": "Organizer error",
             *     "error_message": "This organizer name already exists."
             *   }
             * }
             */
            return response.Content.ReadAsAsync<T>(JsonSerializationHelpers.GetJsonFormatters()).Result;
        }

        //todo: attribute that specifies which displayFields are valid for a given method

        public Event GetEvent(long eventId, params DisplayField[] displayFields)
        {
            var qry = HttpUtility.ParseQueryString(string.Empty);
            qry["id"] = eventId.ToString();
            if (displayFields != null)
                qry["display"] = string.Join<DisplayField>(",", displayFields);
            return this.Get<EventWrapper>("event_get", qry.ToString()).Event;
        }

        public IEnumerable<Attendee> GetAttendees(long eventId, params DisplayField[] displayFields)
        {
            //this method has exclusion based display fields
            var displayFieldsToExclude = new DisplayField[] { DisplayField.Address, DisplayField.Profile, DisplayField.Answers };
            if (displayFields != null)
                displayFieldsToExclude = displayFieldsToExclude.Except(displayFields).ToArray();
            //tbd: is paginate ignored if count and page parameters are not sent? http://developer.eventbrite.com/doc/events/event_list_attendees/
            var qry = HttpUtility.ParseQueryString(string.Empty);
            qry["id"] = eventId.ToString();
            qry["do_not_display"] = string.Join<DisplayField>(",", displayFieldsToExclude);
            return this.Get<AttendeesWrapper>("event_list_attendees", qry.ToString()).Attendees;
        }

        public Organizer GetOrganizer(long organizerId)
        {
            var qry = HttpUtility.ParseQueryString(string.Empty);
            qry["id"] = organizerId.ToString();
            return this.Get<OrganizerWrapper>("organizer_get", qry.ToString()).Organizer;
        }

        public Organizer CreateOrganizer(OrganizerCreationRequest organizer)
        {
            var qry = HttpUtility.ParseQueryString(string.Empty);
            organizer.AddToQuery(qry);
            ProcessResponse response = this.Get<ProcessResponse>("organizer_new", qry.ToString());
            return this.GetOrganizer(response.Id);
        }

        public Organizer CreateOrganizer(string name, string description)
        {
            return this.CreateOrganizer(new OrganizerCreationRequest() { Name = name, Description = description });
        }

        public Venue GetVenue(long venueId)
        {
            var qry = HttpUtility.ParseQueryString(string.Empty);
            qry["id"] = venueId.ToString();
            return this.Get<VenueWrapper>("venue_get", qry.ToString()).Venue;
        }

        public IEnumerable<Venue> ListVenues()
        {
            return this.Get<VenuesWrapper>("user_list_venues", string.Empty).Venues;
        }

        public Venue CreateVenue(VenueCreationRequest venue)
        {
            //TODO: validate venue
            var qry = HttpUtility.ParseQueryString(string.Empty);
            venue.AddToQuery(qry);
            ProcessResponse response = this.Get<ProcessResponse>("venue_new", qry.ToString());
            return this.GetVenue(response.Id);
        }

    }
}
