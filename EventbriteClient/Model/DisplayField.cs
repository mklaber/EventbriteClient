using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventbriteClient.Model
{
    public sealed class DisplayField
    {
        private DisplayField(string displayFieldName) { this.DisplayFieldName = displayFieldName; }
        private readonly string DisplayFieldName;
        public override string ToString()
        {
            return this.DisplayFieldName;
        }

        public static DisplayField CustomHeader = new DisplayField("custom_header");
        public static DisplayField CustomFooter = new DisplayField("custom_footer");
        public static DisplayField ConfirmationPage = new DisplayField("confirmation_page");
        public static DisplayField ConfirmationEmail = new DisplayField("confirmation_email");
        public static DisplayField Profile = new DisplayField("profile");
        public static DisplayField Answers = new DisplayField("answers");
        public static DisplayField Address = new DisplayField("address");

    }
}
