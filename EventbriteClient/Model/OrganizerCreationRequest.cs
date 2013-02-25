using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventbriteClient.Model
{
    public class OrganizerCreationRequest : CreationRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override void AddToQuery(System.Collections.Specialized.NameValueCollection qry)
        {
            base.AddToQuery(qry);
            qry["name"] = this.Name;
            if (!string.IsNullOrEmpty(this.Description))
                qry["description"] = this.Description;
        }
    }
}
