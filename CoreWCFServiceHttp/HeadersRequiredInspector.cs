using CoreWCF.Dispatcher;
using CoreWCF.Web;

namespace CoreWCFServiceHttp;

public class HeadersRequiredInspector : IParameterInspector
{
    public object BeforeCall(string operationName, object[] inputs)
    {
        var headers = WebOperationContext.Current.IncomingRequest.Headers;
        if (!headers.AllKeys.Contains("RequiredHeader"))
            throw new Exception("The request must contain a header RequiredHeader");

        return null;
    }

    public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
    {
    }
}
