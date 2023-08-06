using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum TransactionTypeType
    {
        [XmlEnum("None")]
        None,
        [XmlEnum("LinkEstablish")]
        LinkEstablish,
        [XmlEnum("Release")]
        Release,
        [XmlEnum("Establish")]
        Establish,
        [XmlEnum("PPNotFound")]
        PPNotFound,
        [XmlEnum("PagingStarted")]
        PagingStarted,
        [XmlEnum("ReleaseFromPP")]
        ReleaseFromPP,
        [XmlEnum("PPSetupRejected")]
        PPSetupRejected,
        [XmlEnum("ComsRelease")]
        ComsRelease,
        [XmlEnum("ComsEstablish")]
        ComsEstablish,
        [XmlEnum("SsFac")]
        SsFac,
        [XmlEnum("SsRelease")]
        SsRelease,
        [XmlEnum("SsEstablish")]
        SsEstablish,
        [XmlEnum("ConnHandover")]
        ConnHandover,
        [XmlEnum("LocReg")]
        LocReg,
        [XmlEnum("Detach")]
        Detach,
        [XmlEnum("Cc")]
        Cc,
        [XmlEnum("Ss")]
        Ss,
        [XmlEnum("Coms")]
        Coms,
    }
}