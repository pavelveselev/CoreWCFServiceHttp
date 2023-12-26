using CoreWCF;
using CoreWCF.Web;

namespace CoreWCFServiceHttp
{
    public class Service : IService
    {
        [HeadersRequiredBehavior]
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string GetMyIp()
        {
            var result = string.Empty;
            if (WebOperationContext.Current.IncomingRequest.Headers.AllKeys.Contains("X-Real-IP"))
            {
                result = WebOperationContext.Current.IncomingRequest.Headers["X-Real-IP"];
            }
            else if (OperationContext.Current.IncomingMessageProperties.ContainsKey("CoreWCF.Channels.RemoteEndpointMessageProperty"))
            {
                result = (OperationContext.Current.IncomingMessageProperties["CoreWCF.Channels.RemoteEndpointMessageProperty"] as RemoteEndpointMessageProperty)?.Address;
            }
            return result ?? string.Empty;
        }

        public string GetServiceUrl()
        {
            return OperationContext.Current.IncomingMessageProperties.Via.ToString();
        }
    }
}
