using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;

namespace EventbriteClient
{
    public class EventbriteMessageHandler : MessageProcessingHandler
    {
        private readonly string appKey;
        private readonly string userKey;

        public EventbriteMessageHandler(HttpMessageHandler innerHandler, string appKey, string userKey = null)
            : base(innerHandler)
        {
            this.appKey = appKey;
            this.userKey = userKey;
        }

        protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, System.Threading.CancellationToken cancellationToken)
        {
            return response;
        }

        protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var qry = System.Web.HttpUtility.ParseQueryString(request.RequestUri.Query);
            qry["app_key"] = this.appKey;

            if (!string.IsNullOrEmpty(this.userKey)) qry["user_key"] = this.userKey;

            var qryBuilder = new UriBuilder(request.RequestUri)
            {
                Query = qry.ToString()
            };

            request.RequestUri = qryBuilder.Uri;

            return request;
        }
    }
}
