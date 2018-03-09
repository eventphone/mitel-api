using System.Xml.Serialization;

namespace mitelapi.Messages
{
    public class GetVersions:BaseRequest
    {
    }

    [XmlRoot("GetVersionsResp", Namespace = "")]
    public class GetVersionsResp : BaseResponse
    {
    }
}