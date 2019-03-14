using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Serialization;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "GetData?value={value}")]
        string GetData(string value);

        [OperationContract, WebInvoke(UriTemplate = "/CompositeType", Method = "POST")]
        [XmlSerializerFormat]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        //[OperationContract, WebInvoke(UriTemplate = "/CompositeType", Method = "POST")]
        //string GetDataUsingDataContract(string composite);

        [OperationContract]
        string CheckStatus();

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
