using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using EventbriteClient;
using EventbriteClient.Model;
using System.Collections.Generic;
using System.Linq;

namespace EventbriteClient.Tests
{
    [TestClass]
    public class SerializationTests
    {

        public void Can_Deserialize_Event_Attendees()
        {
            string json = @"{
  ""attendees"": [
    {
      ""attendee"": {
        ""first_name"": ""Alicia"",
        ""last_name"": ""Byrd"",
        ""home_city"": ""Somerville"",
        ""event_id"": 5491057902,
        ""answers"": [],
        ""id"": 181052782
      }
    },
    {
      ""attendee"": {
        ""website"": ""http://www.jessfaulk.com"",
        ""first_name"": ""Jess"",
        ""last_name"": ""Faulk"",
        ""home_city"": ""Boston"",
        ""suffix"": """",
        ""event_id"": 5491057902,
        ""company"": ""Simmons College"",
        ""answers"": [
          {
            ""answer"": {
              ""answer_text"": ""http://www.twitter.com/jessfaulk"",
              ""question"": ""What's your twitter handle? Type out full url (e.g. http://twitter.com/sojust). More than one? Press enter before adding another."",
              ""question_type"": ""text"",
              ""question_id"": 3483372
            }
          }
        ],
        ""blog"": """",
        ""prefix"": """",
        ""id"": 180890134,
        ""job_title"": ""Director of Residence Life""
      }
    },
    {
      ""attendee"": {
        ""website"": ""http://www.sojust.org"",
        ""first_name"": ""Robbie"",
        ""last_name"": ""Samuels"",
        ""home_city"": ""Boston"",
        ""suffix"": """",
        ""event_id"": 5491057902,
        ""company"": ""Socializing for Justice"",
        ""answers"": [
          {
            ""answer"": {
              ""answer_text"": ""http://www.twitter.com/robbiesamuels"",
              ""question"": ""What's your twitter handle? Type out full url (e.g. http://twitter.com/sojust). More than one? Press enter before adding another."",
              ""question_type"": ""text"",
              ""question_id"": 3483372
            }
          }
        ],
        ""blog"": ""http://www.robbiesamuels.com"",
        ""prefix"": """",
        ""id"": 180890132,
        ""job_title"": ""Co-Founder""
      }
    }
  ]
}";
        }

        [TestMethod]
        public void Can_Deserialize_Ticket()
        {

            string json = @"{
        ""ticket"": {
          ""description"": ""To make RootsCamp MA accessible to a broad range of progressive activists, the minimum fee is $10. Breakfast, lunch and snacks for two days are included with this fee."",
          ""end_date"": ""2013-04-05T21:30:00"",
          ""min"": 1,
          ""max"": 0,
          ""price"": ""11.19"",
          ""visible"": ""true"",
          ""start_date"": ""2013-04-06T09:30:00"",
          ""currency"": ""USD"",
          ""type"": 0,
          ""Id"": 17124914,
          ""name"": ""Discounted Ticket""
        }
}";

            var settings = (JsonSerializationHelpers.GetJsonFormatters().First() as System.Net.Http.Formatting.JsonMediaTypeFormatter).SerializerSettings;
            TicketWrapper ticketWrapper = JsonConvert.DeserializeObject<TicketWrapper>(json, settings);
            Assert.IsNotNull(ticketWrapper.Ticket);
            Ticket ticket = ticketWrapper.Ticket;

            Assert.AreEqual("Discounted Ticket", ticket.Name);
            Assert.AreEqual(17124914L, ticket.Id);
            Assert.AreEqual(new DateTime(2013, 04, 06, 09, 30, 00), ticket.StartDate);
        }

        [TestMethod]
        public void Can_Serialize_Ticket()
        {
            Ticket ticket = new Ticket()
            {
                StartDate = new DateTime(2013, 4, 6, 9, 30, 0),
                Id = 17124914,
                Name = "Discounted Ticket"
            };
            var settings = (JsonSerializationHelpers.GetJsonFormatters().First() as System.Net.Http.Formatting.JsonMediaTypeFormatter).SerializerSettings;
            string json = JsonConvert.SerializeObject(ticket, settings);
            Assert.AreEqual("blah", json);
        }

    }
}
