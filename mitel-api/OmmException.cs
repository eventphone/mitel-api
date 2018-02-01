using System;
using System.Collections.Generic;
using mitelapi.Messages;

namespace mitelapi
{
    public class OmmException : Exception
    {
        private static readonly Dictionary<OmmError, string> _messages = new Dictionary<OmmError, string>
        {
            {OmmError.EAreaFull, "Paging area is full"},
            {OmmError.EAuth, "Authentication failed, e. g. user name or password may be wrong"},
            {OmmError.EDectRegDomainInvalid, "A DECT regulatory domain must be set before the request can be performed"},
            {OmmError.EEncryptNotAllowed, "DECT encryption cannot be activated because of at least one RFP not supporting encryption is connected."},
            {OmmError.EExist, "A field describing a unique attribute does already exist"},
            {OmmError.EFailed, "Request could not be fulfilled"},
            {OmmError.EForbidden, "This operation is not permitted with that instance"},
            {OmmError.EInProgress, "Another transaction is in progress, this request cannot be fulfilled currently"},
            {OmmError.EInval, "A field contains invalid data or exceeds a limit"},
            {OmmError.EInvalidChars, "A string contains invalid characters."},
            {OmmError.ELicense, "Operation cannot be fulfilled because of license restrictions"},
            {OmmError.ELicenseFile, "Operation cannot be fulfilled because of license file restrictions"},
            {OmmError.ELicenseWrongInstallId, "Operation cannot be fulfilled because of an invalid installation id in the license file"},
            {OmmError.EMissing, "A field which is mandatory on this OMM version is missing"},
            {OmmError.ENoEnt, "No record found for given key or id"},
            {OmmError.ENoMem, "No more data sets can be created"},
            {OmmError.EPerm, "No sufficient permissions for this request"},
            {OmmError.EPwEmpty, "A required password was not specified."},
            {OmmError.EPwSimilarToHost, "A new given password is too similar to the host name."},
            {OmmError.EPwSimilarToName, "A new given password is too similar to the user name."},
            {OmmError.EPwTooManySimilarChars, "A new given password too many similar characters."},
            {OmmError.EPwTooShort, "A new given password is too short."},
            {OmmError.EPwTooSimilar, "A new given password is too similar to the previous one."},
            {OmmError.EPwTooWeak, "A new given password is too weak."},
            {OmmError.EPwUnchanged, "A new given password does not differ to the old one."},
            {OmmError.ETooLong, "A string is too long"},
            {OmmError.EWlanRegDomainInvalid, "A DECT regulatory domain must be set before the request can be performed"},
        };
        public OmmException(OmmError errorCode, string info, string errorBad, int? errorMaxLength)
            :base(_messages[errorCode])
        {
            ErrorCode = errorCode;
            Info = info;
            Bad = errorBad;
            MaxLength = errorMaxLength;
        }

        public int? MaxLength { get; set; }

        public string Bad { get; set; }

        public string Info { get; set; }

        public OmmError ErrorCode { get; set; }
    }
}