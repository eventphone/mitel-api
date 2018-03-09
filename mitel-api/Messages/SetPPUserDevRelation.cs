using mitelapi.Types;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// SetPPUserDevRelation The client can send this request to OM AXI to change the relation between a  
    /// DECT phone user and a DECT phone device data set.
    /// The User ID (uid) has to be filled in by the client to identify the  DECT phone user data set to be changed.
    /// Additionally the relation attribute must be filled in by the client. 
    /// </summary>
    /// <remarks>It is only possible to change a relationship between a user and a 
    /// DECT phone device from Fixed to Dynamic and from Dynamic to Fixed. 
    /// The client needs one of these permissions to use this request: AllCnfWrite
    /// </remarks>
    [XmlRoot("SetPPUserDevRelation", Namespace = "")]
    public class SetPPUserDevRelation : BaseRequest {
        
        /// <summary>
        /// User ID, of the user data set
        /// </summary>
        [XmlAttribute("uid")]
        public int Uid {get; set;}

        /// <summary>
        /// Type or state of a relationship to the  DECT phone device to be set.
        /// </summary>
        [XmlAttribute("relType")]
        public PPRelTypeType RelType {get; set;}
    }

    /// <summary>
    /// The reply to a <see cref="SetPPUserDevRelation"/> request. 
    /// It contains all actual set attributes, all attributes are optional.
    /// </summary>
    /// <remarks>
    /// The Event notification for this change is done by <see cref="EventPPDevCnf"/> and <see cref="EventPPUserCnf"/>.
    /// </remarks>
    [XmlRoot("SetPPUserDevRelationResp", Namespace = "")]
    public class SetPPUserDevRelationResp : BaseResponse 
    {
        /// <summary>
        /// User ID, of the user data set
        /// </summary>
        [XmlAttribute("uid")]
        public int Uid {get; set;}

        /// <summary>
        /// Type or state of a relationship to the DECT phone device that has been set.
        /// </summary>
        [XmlAttribute("relType")]
        public PPRelTypeType RelType {get; set;}
    }
}