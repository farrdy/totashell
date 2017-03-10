using System;
using System.Xml.Serialization;

namespace Total.DealerCom.Core
{
    [Serializable]
    [XmlRoot("template")]
    public class EmailTemplate
    {
        private string _claimant;
        private string _ourReference;
        private string _yourReference;
        private string _personSigning;
        private string _designation;
        private string _email;
        private string _emailTo;

        [XmlElement("claimant")]
        public string Claimant
        {
            get { return _claimant; }
            set { _claimant = value; }
        }

        [XmlElement("ourReference")]
        public string OurReference
        {
            get { return _ourReference; }
            set { _ourReference = value; }
        }

        [XmlElement("yourReference")]
        public string YourReference
        {
            get { return _yourReference; }
            set { _yourReference = value; }
        }

        [XmlElement("personSigning")]
        public string PersonSigning
        {
            get { return _personSigning; }
            set { _personSigning = value; }
        }

        [XmlElement("designation")]
        public string Designation
        {
            get { return _designation; }
            set { _designation = value; }
        }

        [XmlElement("email")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string EmailTo
        {
            get { return _emailTo; }
            set { _emailTo = value; }
        }

    }
}