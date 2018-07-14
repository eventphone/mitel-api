using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum OmmError
    {
        None,
        /// <summary>
        /// Paging area is full
        /// </summary>
        [XmlEnum("EAreaFull")]
        EAreaFull,
        /// <summary>
        /// Authentication failed, e. g. user name or password may be wrong
        /// </summary>
        [XmlEnum("EAuth")]
        EAuth, 
        /// <summary>
        /// A DECT regulatory domain must be set before the request can be performed
        /// </summary>
        [XmlEnum("EDectRegDomainInvalid")]
        EDectRegDomainInvalid, 
        /// <summary>
        /// DECT encryption cannot be activated because of at least one RFP not supporting encryption is connected.
        /// </summary>
        [XmlEnum("EEncryptNotAllowed")]
        EEncryptNotAllowed,
        /// <summary>
        /// A field describing a unique attribute does already exist
        /// </summary>
        [XmlEnum("EExist")]
        EExist,
        /// <summary>
        /// Request could not be fulfilled
        /// </summary>
        [XmlEnum("EFailed")]
        EFailed, 
        /// <summary>
        /// This operation is not permitted with that instance
        /// </summary>
        [XmlEnum("EForbidden")]
        EForbidden,
        /// <summary>
        /// Another transaction is in progress, this request cannot be fulfilled currently
        /// </summary>
        [XmlEnum("EInProgress")]
        EInProgress,
        /// <summary>
        /// A field contains invalid data or exceeds a limit
        /// </summary>
        [XmlEnum("EInval")]
        EInval,
        /// <summary>
        /// A string contains invalid characters.
        /// </summary>
        [XmlEnum("EInvalidChars")]
        EInvalidChars,
        /// <summary>
        /// Operation cannot be fulfilled because of license restrictions
        /// </summary>
        [XmlEnum("ELicense")]
        ELicense,
        /// <summary>
        /// Operation cannot be fulfilled because of license file restrictions
        /// </summary>
        [XmlEnum("ELicenseFile")]
        ELicenseFile,
        /// <summary>
        /// Operation cannot be fulfilled because of an invalid installation id in the license file
        /// </summary>
        [XmlEnum("ELicenseWrongInstallId")]
        ELicenseWrongInstallId,
        /// <summary>
        /// A field which is mandatory on this OMM version is missing
        /// </summary>
        [XmlEnum("EMissing")]
        EMissing, 
        /// <summary>
        /// No record found for given key or id
        /// </summary>
        [XmlEnum("ENoEnt")]
        ENoEnt, 
        /// <summary>
        /// No more data sets can be created
        /// </summary>
        [XmlEnum("ENoMem")]
        ENoMem,
        /// <summary>
        /// No sufficient permissions for this request
        /// </summary>
        [XmlEnum("EPerm")]
        EPerm,
        /// <summary>
        /// A required password was not specified.
        /// </summary>
        [XmlEnum("EPwEmpty")]
        EPwEmpty,
        /// <summary>
        /// A new given password is too similar to the host name.
        /// </summary>
        [XmlEnum("EPwSimilarToHost")]
        EPwSimilarToHost, 
        /// <summary>
        /// A new given password is too similar to the user name.
        /// </summary>
        [XmlEnum("EPwSimilarToName")]
        EPwSimilarToName,
        /// <summary>
        /// A new given password too many similar characters.
        /// </summary>
        [XmlEnum("EPwTooManySimilarChars")]
        EPwTooManySimilarChars,
        /// <summary>
        /// A new given password is too short.
        /// </summary>
        [XmlEnum("EPwTooShort")]
        EPwTooShort,
        /// <summary>
        /// A new given password is too similar to the previous one.
        /// </summary>
        [XmlEnum("EPwTooSimilar")]
        EPwTooSimilar, 
        /// <summary>
        /// A new given password is too weak.
        /// </summary>
        [XmlEnum("EPwTooWeak")]
        EPwTooWeak, 
        /// <summary>
        /// A new given password does not differ to the old one.
        /// </summary>
        [XmlEnum("EPwUnchanged")]
        EPwUnchanged,
        /// <summary>
        /// A string is too long
        /// </summary>
        [XmlEnum("ETooLong")]
        ETooLong,
        /// <summary>
        /// A DECT regulatory domain must be set before the request can be performed
        /// </summary>
        [XmlEnum("EWlanRegDomainInvalid")]
        EWlanRegDomainInvalid,
    }
}