using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace EventbriteClient.Model
{
    public abstract class CreationRequest
    {
        public virtual void AddToQuery(NameValueCollection qry)
        {
            //todo: use Json.Net to find all of this type's properties?
        }
    }
}
