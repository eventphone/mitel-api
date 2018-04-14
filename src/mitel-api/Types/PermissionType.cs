using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum PermissionType
    {
        /// <summary>
        /// Permission to write to the configuration database, will automatically set permission AllCnfRead
        /// </summary>
        [XmlEnum("AllCnfWrite")]
        AllCnfWrite,
        /// <summary>
        /// Permission to read all data from configuration database
        /// </summary>
        [XmlEnum("AllCnfRead")]
        AllCnfRead,
        /// <summary>
        /// Permission to send messages only for priority Info and to subscribe to message events
        /// </summary>
        [XmlEnum("InfoMessaging")]
        InfoMessaging,
        /// <summary>
        /// Permission to send messages and to subscribe to message events, except with priority Emergency and LocatingAlert; will automatically set permission InfoMessaging.
        /// </summary>
        [XmlEnum("Messaging")]
        Messaging,
        /// <summary>
        /// Permission to send messages with priority Emergency, will automatically set permission Messaging and InfoMessaging
        /// </summary>
        [XmlEnum("Alerting")]
        Alerting,
        /// <summary>
        /// Permission to send messages with priority LocatingAlert, will automatically set permission Messaging and InfoMessaging
        /// </summary>
        [XmlEnum("LocatingAlert")]
        LocatingAlert,
        /// <summary>
        /// Permission to query the position of DECT phones and to track DECT phone positions
        /// </summary>
        [XmlEnum("Locating")]
        Locating,
        /// <summary>
        /// Permission to monitor various technical aspects of the mobility system, will automatically set permission AllCnfRead
        /// </summary>
        [XmlEnum("Monitoring")]
        Monitoring,
        /// <summary>
        /// Permission to use conferencing in the open mobility system will automatically set permission AllCnfRead.
        /// </summary>
        [XmlEnum("Conferencing")]
        Conferencing,
        /// <summary>
        /// Permission to use video in the mobility system, will automatically set permission AllCnfRead.
        /// </summary>
        [XmlEnum("Video")]
        Video,
    }
}