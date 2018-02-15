using System.Xml.Serialization;

namespace mitelapi.Messages
{
    //<GetRFPSummary />
    public class GetRFPSummary:BaseRequest
    {
    }
    
    //<GetRFPSummaryResp nRFPs="5" idFirst="1" nConnected="2" wrongBrandedRFPs="0" wrongStandbyRFPs="0" 
    // wrongVersionedRFPs="0" newAvailSWRFPs="0" DecryptedDECTRFPs="0" usbOverloads="0" DECTactivatedRFPs="1"
    // DECTactiveRFPs="0" advancedFeaturesErrorRFPs="0" usedDECTclusters="1" usedPagingAreas="1"
    // WLANactivatedRFPs="1" WLANrunningRFPs="1" usedWLANprofiles="1" />
    [XmlRoot("GetRFPSummaryResp", Namespace = "")]
    public class GetRFPSummaryResp : BaseResponse
    {
        [XmlAttribute("nRFPs")]
        public int TotalCount { get; set; }

        [XmlAttribute("DECTactiveRFPs")]
        public int DectActiveCount { get; set; }

        [XmlAttribute("DECTactivatedRFPs")]
        public int DectActivatedCount { get; set; }

        [XmlAttribute("nConnected")]
        public int ConnectedCount { get; set; }
    }
}