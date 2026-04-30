using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Response
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
    public partial class Envelope
    {

        private EnvelopeBody bodyField;

        /// <remarks/>
        public EnvelopeBody Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public partial class EnvelopeBody
    {

        private COREEnvelopeRealTimeResponse cOREEnvelopeRealTimeResponseField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.caqh.org/SOAP/WSDL/CORERule2.2.0.xsd")]
        public COREEnvelopeRealTimeResponse COREEnvelopeRealTimeResponse
        {
            get
            {
                return this.cOREEnvelopeRealTimeResponseField;
            }
            set
            {
                this.cOREEnvelopeRealTimeResponseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.caqh.org/SOAP/WSDL/CORERule2.2.0.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.caqh.org/SOAP/WSDL/CORERule2.2.0.xsd", IsNullable = false)]
    public partial class COREEnvelopeRealTimeResponse
    {

        private string payloadTypeField;

        private string processingModeField;

        private string payloadIDField;

        private System.DateTime timeStampField;

        private string senderIDField;

        private string receiverIDField;

        private string cORERuleVersionField;

        private string errorCodeField;

        private string errorMessageField;

        private string payloadField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string PayloadType
        {
            get
            {
                return this.payloadTypeField;
            }
            set
            {
                this.payloadTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string ProcessingMode
        {
            get
            {
                return this.processingModeField;
            }
            set
            {
                this.processingModeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string PayloadID
        {
            get
            {
                return this.payloadIDField;
            }
            set
            {
                this.payloadIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public System.DateTime TimeStamp
        {
            get
            {
                return this.timeStampField;
            }
            set
            {
                this.timeStampField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string SenderID
        {
            get
            {
                return this.senderIDField;
            }
            set
            {
                this.senderIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string ReceiverID
        {
            get
            {
                return this.receiverIDField;
            }
            set
            {
                this.receiverIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string CORERuleVersion
        {
            get
            {
                return this.cORERuleVersionField;
            }
            set
            {
                this.cORERuleVersionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string ErrorCode
        {
            get
            {
                return this.errorCodeField;
            }
            set
            {
                this.errorCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string ErrorMessage
        {
            get
            {
                return this.errorMessageField;
            }
            set
            {
                this.errorMessageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string Payload
        {
            get
            {
                return this.payloadField;
            }
            set
            {
                this.payloadField = value;
            }
        }
    }

}
