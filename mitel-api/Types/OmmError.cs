using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum OmmError
    {
        None,
        /// <summary>
        /// Paging area is full
        /// </summary>
        [XmlEnum(Name = "EAreaFull")]
        EAreaFull,
        /// <summary>
        /// Authentication failed, e. g. user name or password may be wrong
        /// </summary>
        [XmlEnum(Name = "EAuth")]
        EAuth, 
        /// <summary>
        /// A DECT regulatory domain must be set before the request can be performed
        /// </summary>
        [XmlEnum(Name = "EDectRegDomainInvalid")]
        EDectRegDomainInvalid, 
        /// <summary>
        /// DECT encryption cannot be activated because of at least one RFP not supporting encryption is connected.
        /// </summary>
        [XmlEnum(Name = "EEncryptNotAllowed")]
        EEncryptNotAllowed,
        /// <summary>
        /// A field describing a unique attribute does already exist
        /// </summary>
        [XmlEnum(Name = "EExist")]
        EExist,
        /// <summary>
        /// Request could not be fulfilled
        /// </summary>
        [XmlEnum(Name = "EFailed")]
        EFailed, 
        /// <summary>
        /// This operation is not permitted with that instance
        /// </summary>
        [XmlEnum(Name = "EForbidden")]
        EForbidden,
        /// <summary>
        /// Another transaction is in progress, this request cannot be fulfilled currently
        /// </summary>
        [XmlEnum(Name = "EInProgress")]
        EInProgress,
        /// <summary>
        /// A field contains invalid data or exceeds a limit
        /// </summary>
        [XmlEnum(Name = "EInval")]
        EInval,
        /// <summary>
        /// A string contains invalid characters.
        /// </summary>
        [XmlEnum(Name = "EInvalidChars")]
        EInvalidChars,
        /// <summary>
        /// Operation cannot be fulfilled because of license restrictions
        /// </summary>
        [XmlEnum(Name = "ELicense")]
        ELicense,
        /// <summary>
        /// Operation cannot be fulfilled because of license file restrictions
        /// </summary>
        [XmlEnum(Name = "ELicenseFile")]
        ELicenseFile,
        /// <summary>
        /// Operation cannot be fulfilled because of an invalid installation id in the license file
        /// </summary>
        [XmlEnum(Name = "ELicenseWrongInstallId")]
        ELicenseWrongInstallId,
        /// <summary>
        /// A field which is mandatory on this OMM version is missing
        /// </summary>
        [XmlEnum(Name = "EMissing")]
        EMissing, 
        /// <summary>
        /// No record found for given key or id
        /// </summary>
        [XmlEnum(Name = "ENoEnt")]
        ENoEnt, 
        /// <summary>
        /// No more data sets can be created
        /// </summary>
        [XmlEnum(Name = "ENoMem")]
        ENoMem,
        /// <summary>
        /// No sufficient permissions for this request
        /// </summary>
        [XmlEnum(Name = "EPerm")]
        EPerm,
        /// <summary>
        /// A required password was not specified.
        /// </summary>
        [XmlEnum(Name = "EPwEmpty")]
        EPwEmpty,
        /// <summary>
        /// A new given password is too similar to the host name.
        /// </summary>
        [XmlEnum(Name = "EPwSimilarToHost")]
        EPwSimilarToHost, 
        /// <summary>
        /// A new given password is too similar to the user name.
        /// </summary>
        [XmlEnum(Name = "EPwSimilarToName")]
        EPwSimilarToName,
        /// <summary>
        /// A new given password too many similar characters.
        /// </summary>
        [XmlEnum(Name = "EPwTooManySimilarChars")]
        EPwTooManySimilarChars,
        /// <summary>
        /// A new given password is too short.
        /// </summary>
        [XmlEnum(Name = "EPwTooShort")]
        EPwTooShort,
        /// <summary>
        /// A new given password is too similar to the previous one.
        /// </summary>
        [XmlEnum(Name = "EPwTooSimilar")]
        EPwTooSimilar, 
        /// <summary>
        /// A new given password is too weak.
        /// </summary>
        [XmlEnum(Name = "EPwTooWeak")]
        EPwTooWeak, 
        /// <summary>
        /// A new given password does not differ to the old one.
        /// </summary>
        [XmlEnum(Name = "EPwUnchanged")]
        EPwUnchanged,
        /// <summary>
        /// A string is too long
        /// </summary>
        [XmlEnum(Name = "ETooLong")]
        ETooLong,
        /// <summary>
        /// A DECT regulatory domain must be set before the request can be performed
        /// </summary>
        [XmlEnum(Name = "EWlanRegDomainInvalid")]
        EWlanRegDomainInvalid,
    }
}