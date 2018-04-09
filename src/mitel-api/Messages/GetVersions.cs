using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// This request is sent from the client to the OMM to request the versions of requests/responses or events.
    /// </summary>
    [XmlRoot("GetVersions")]
    public class GetVersions:BaseRequest
    {
    }

    public class GetVersionsResp : BaseResponse
    {
        /// <summary>
        /// Version string of the request/response elements ‘ActivateRemoteSystemDump'.
        /// </summary>
        [XmlAttribute("ActivateRemoteSystemDump")]
        public string ActivateRemoteSystemDump { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘AddUserToConference'.
        /// </summary>
        [XmlAttribute("AddUserToConference")]
        public string AddUserToConference { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CancelMessage'.
        /// </summary>
        [XmlAttribute("CancelMessage")]
        public string CancelMessage { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘ChangeUserInConference'.
        /// </summary>
        [XmlAttribute("ChangeUserInConference")]
        public string ChangeUserInConference { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CreateAccount'.
        /// </summary>
        [XmlAttribute("CreateAccount")]
        public string CreateAccount { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CreateACLEntry'.
        /// </summary>
        [XmlAttribute("CreateACLEntry")]
        public string CreateACLEntry { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CreateAlarmTrigger'.
        /// </summary>
        [XmlAttribute("CreateAlarmTrigger")]
        public string CreateAlarmTrigger { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CreateBluetoothBeacon'.
        /// </summary>
        [XmlAttribute("CreateBluetoothBeacon")]
        public string CreateBluetoothBeacon { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CreateConference'.
        /// </summary>
        [XmlAttribute("CreateConference")]
        public string CreateConference { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CreateDigitTreatment'.
        /// </summary>
        [XmlAttribute("CreateDigitTreatment")]
        public string CreateDigitTreatment { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CreateFixedPP'.
        /// </summary>
        [XmlAttribute("CreateFixedPP")]
        public string CreateFixedPP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CreateLDAP'.
        /// </summary>
        [XmlAttribute("CreateLDAP")]
        public string CreateLDAP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CreatePPDev'.
        /// </summary>
        [XmlAttribute("CreatePPDev")]
        public string CreatePPDev { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CreatePPUser'.
        /// </summary>
        [XmlAttribute("CreatePPUser")]
        public string CreatePPUser { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CreateRFP'.
        /// </summary>
        [XmlAttribute("CreateRFP")]
        public string CreateRFP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CreateSite'.
        /// </summary>
        [XmlAttribute("CreateSite")]
        public string CreateSite { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CreateVideoDev'.
        /// </summary>
        [XmlAttribute("CreateVideoDev")]
        public string CreateVideoDev { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CreateWLANProfile'.
        /// </summary>
        [XmlAttribute("CreateWLANProfile")]
        public string CreateWLANProfile { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘CreateXMLApplication'.
        /// </summary>
        [XmlAttribute("CreateXMLApplication")]
        public string CreateXMLApplication { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DBBackupToUSB'.
        /// </summary>
        [XmlAttribute("DBBackupToUSB")]
        public string DBBackupToUSB { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DBRestoreFromUSB'.
        /// </summary>
        [XmlAttribute("DBRestoreFromUSB")]
        public string DBRestoreFromUSB { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteAccount'.
        /// </summary>
        [XmlAttribute("DeleteAccount")]
        public string DeleteAccount { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteACLEntry'.
        /// </summary>
        [XmlAttribute("DeleteACLEntry")]
        public string DeleteACLEntry { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteAlarmTrigger'.
        /// </summary>
        [XmlAttribute("DeleteAlarmTrigger")]
        public string DeleteAlarmTrigger { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteBluetoothBeacon'.
        /// </summary>
        [XmlAttribute("DeleteBluetoothBeacon")]
        public string DeleteBluetoothBeacon { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteConference'.
        /// </summary>
        [XmlAttribute("DeleteConference")]
        public string DeleteConference { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteDigitTreatment'.
        /// </summary>
        [XmlAttribute("DeleteDigitTreatment")]
        public string DeleteDigitTreatment { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteEventLogBuffer'.
        /// </summary>
        [XmlAttribute("DeleteEventLogBuffer")]
        public string DeleteEventLogBuffer { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteLDAP'.
        /// </summary>
        [XmlAttribute("DeleteLDAP")]
        public string DeleteLDAP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteMessage'.
        /// </summary>
        [XmlAttribute("DeleteMessage")]
        public string DeleteMessage { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeletePPDev'.
        /// </summary>
        [XmlAttribute("DeletePPDev")]
        public string DeletePPDev { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeletePPUser'.
        /// </summary>
        [XmlAttribute("DeletePPUser")]
        public string DeletePPUser { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteRFP'.
        /// </summary>
        [XmlAttribute("DeleteRFP")]
        public string DeleteRFP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteRFPCaptureList'.
        /// </summary>
        [XmlAttribute("DeleteRFPCaptureList")]
        public string DeleteRFPCaptureList { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteRFPCaptureListElem'.
        /// </summary>
        [XmlAttribute("DeleteRFPCaptureListElem")]
        public string DeleteRFPCaptureListElem { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteSite'.
        /// </summary>
        [XmlAttribute("DeleteSite")]
        public string DeleteSite { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteUserFromConference'.
        /// </summary>
        [XmlAttribute("DeleteUserFromConference")]
        public string DeleteUserFromConference { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteVideoDev'.
        /// </summary>
        [XmlAttribute("DeleteVideoDev")]
        public string DeleteVideoDev { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteWLANProfile'.
        /// </summary>
        [XmlAttribute("DeleteWLANProfile")]
        public string DeleteWLANProfile { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘DeleteXMLApplication'.
        /// </summary>
        [XmlAttribute("DeleteXMLApplication")]
        public string DeleteXMLApplication { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventAccountCnf'.
        /// </summary>
        [XmlAttribute("EventAccountCnf")]
        public string EventAccountCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventAccountSummary'.
        /// </summary>
        [XmlAttribute("EventAccountSummary")]
        public string EventAccountSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventACLCnf'.
        /// </summary>
        [XmlAttribute("EventACLCnf")]
        public string EventACLCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventAddUserToConference'.
        /// </summary>
        [XmlAttribute("EventAddUserToConference")]
        public string EventAddUserToConference { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventAdvancedSIPCnf'.
        /// </summary>
        [XmlAttribute("EventAdvancedSIPCnf")]
        public string EventAdvancedSIPCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventAlarmCallProgress'.
        /// </summary>
        [XmlAttribute("EventAlarmCallProgress")]
        public string EventAlarmCallProgress { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventAlarmTrigger'.
        /// </summary>
        [XmlAttribute("EventAlarmTrigger")]
        public string EventAlarmTrigger { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventAlarmTriggerCnf'.
        /// </summary>
        [XmlAttribute("EventAlarmTriggerCnf")]
        public string EventAlarmTriggerCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventAutoDBBackupCnf'.
        /// </summary>
        [XmlAttribute("EventAutoDBBackupCnf")]
        public string EventAutoDBBackupCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventAutoDBBackupFileNameCnf'.
        /// </summary>
        [XmlAttribute("EventAutoDBBackupFileNameCnf")]
        public string EventAutoDBBackupFileNameCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventBasicSIPCnf'.
        /// </summary>
        [XmlAttribute("EventBasicSIPCnf")]
        public string EventBasicSIPCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventBackupSIPCnf'.
        /// </summary>
        [XmlAttribute("EventBackupSIPCnf")]
        public string EventBackupSIPCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventBluetoothClientStatistic'.
        /// </summary>
        [XmlAttribute("EventBluetoothClientStatistic")]
        public string EventBluetoothClientStatistic { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventBluetoothBeaconCnf'.
        /// </summary>
        [XmlAttribute("EventBluetoothBeaconCnf")]
        public string EventBluetoothBeaconCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventBluetoothBeaconSummary'.
        /// </summary>
        [XmlAttribute("EventBluetoothBeaconSummary")]
        public string EventBluetoothBeaconSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventBluetoothGlobalSettingsCnf'.
        /// </summary>
        [XmlAttribute("EventBluetoothGlobalSettingsCnf")]
        public string EventBluetoothGlobalSettingsCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventBluetoothSensitivityCnf'.
        /// </summary>
        [XmlAttribute("EventBluetoothSensitivityCnf")]
        public string EventBluetoothSensitivityCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventChangeUserInConference'.
        /// </summary>
        [XmlAttribute("EventChangeUserInConference")]
        public string EventChangeUserInConference { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventCreateConference'.
        /// </summary>
        [XmlAttribute("EventCreateConference")]
        public string EventCreateConference { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventConferenceRelease'.
        /// </summary>
        [XmlAttribute("EventConferenceRelease")]
        public string EventConferenceRelease { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventConferenceRequest'.
        /// </summary>
        [XmlAttribute("EventConferenceRequest")]
        public string EventConferenceRequest { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventConferenceRoomCnf'.
        /// </summary>
        [XmlAttribute("EventConferenceRoomCnf")]
        public string EventConferenceRoomCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventConferenceServerSIP'.
        /// </summary>
        [XmlAttribute("EventConferenceServerSIP")]
        public string EventConferenceServerSIP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventConfigURLCnf'.
        /// </summary>
        [XmlAttribute("EventConfigURLCnf")]
        public string EventConfigURLCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventCoreDumpURLCnf'.
        /// </summary>
        [XmlAttribute("EventCoreDumpURLCnf")]
        public string EventCoreDumpURLCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventDbTransferState'.
        /// </summary>
        [XmlAttribute("EventDbTransferState")]
        public string EventDbTransferState { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventDECTAuthCodeCnf'.
        /// </summary>
        [XmlAttribute("EventDECTAuthCodeCnf")]
        public string EventDECTAuthCodeCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventDECTEncryptionCnf'.
        /// </summary>
        [XmlAttribute("EventDECTEncryptionCnf")]
        public string EventDECTEncryptionCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventDECTPagingAreaSizeCnf'.
        /// </summary>
        [XmlAttribute("EventDECTPagingAreaSizeCnf")]
        public string EventDECTPagingAreaSizeCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventDECTPowerLimitCnf'.
        /// </summary>
        [XmlAttribute("EventDECTPowerLimitCnf")]
        public string EventDECTPowerLimitCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventDECTPpSettingsCnf'.
        /// </summary>
        [XmlAttribute("EventDECTPpSettingsCnf")]
        public string EventDECTPpSettingsCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventDECTRegDomainCnf'.
        /// </summary>
        [XmlAttribute("EventDECTRegDomainCnf")]
        public string EventDECTRegDomainCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventDECTSubscriptionMode'.
        /// </summary>
        [XmlAttribute("EventDECTSubscriptionMode")]
        public string EventDECTSubscriptionMode { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventDeleteConference'.
        /// </summary>
        [XmlAttribute("EventDeleteConference")]
        public string EventDeleteConference { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventDeleteUserFromConference'.
        /// </summary>
        [XmlAttribute("EventDeleteUserFromConference")]
        public string EventDeleteUserFromConference { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventDevAutoCreateCnf'.
        /// </summary>
        [XmlAttribute("EventDevAutoCreateCnf")]
        public string EventDevAutoCreateCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventDigitTreatmentCnf'.
        /// </summary>
        [XmlAttribute("EventDigitTreatmentCnf")]
        public string EventDigitTreatmentCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventDTMFCnf'.
        /// </summary>
        [XmlAttribute("EventDTMFCnf")]
        public string EventDTMFCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventEULAConfirmCnf'.
        /// </summary>
        [XmlAttribute("EventEULAConfirmCnf")]
        public string EventEULAConfirmCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventEventLogEntry'.
        /// </summary>
        [XmlAttribute("EventEventLogEntry")]
        public string EventEventLogEntry { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventFACCnf'.
        /// </summary>
        [XmlAttribute("EventFACCnf")]
        public string EventFACCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventFACPrefixCnf'.
        /// </summary>
        [XmlAttribute("EventFACPrefixCnf")]
        public string EventFACPrefixCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventFreeConferenceChannels'.
        /// </summary>
        [XmlAttribute("EventFreeConferenceChannels")]
        public string EventFreeConferenceChannels { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventHealthState'.
        /// </summary>
        [XmlAttribute("EventHealthState")]
        public string EventHealthState { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventIMACnf'.
        /// </summary>
        [XmlAttribute("EventIMACnf")]
        public string EventIMACnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventIntercomCallHandlingSIPCnf'.
        /// </summary>
        [XmlAttribute("EventIntercomCallHandlingSIPCnf")]
        public string EventIntercomCallHandlingSIPCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventLDAPCnf'.
        /// </summary>
        [XmlAttribute("EventLDAPCnf")]
        public string EventLDAPCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventLicenseCnf'.
        /// </summary>
        [XmlAttribute("EventLicenseCnf")]
        public string EventLicenseCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventLicensedCodecLines'.
        /// </summary>
        [XmlAttribute("EventLicensedCodecLines")]
        public string EventLicensedCodecLines { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventLicenseFile'.
        /// </summary>
        [XmlAttribute("EventLicenseFile")]
        public string EventLicenseFile { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventLicenseServerListCnf'.
        /// </summary>
        [XmlAttribute("EventLicenseServerListCnf")]
        public string EventLicenseServerListCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventMessageConfirmation'.
        /// </summary>
        [XmlAttribute("EventMessageConfirmation")]
        public string EventMessageConfirmation { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventMessageProgress'.
        /// </summary>
        [XmlAttribute("EventMessageProgress")]
        public string EventMessageProgress { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventMessageQueueEmpty'.
        /// </summary>
        [XmlAttribute("EventMessageQueueEmpty")]
        public string EventMessageQueueEmpty { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventMessageSend'.
        /// </summary>
        [XmlAttribute("EventMessageSend")]
        public string EventMessageSend { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventNTPServerCnf'.
        /// </summary>
        [XmlAttribute("EventNTPServerCnf")]
        public string EventNTPServerCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventOMMCertificateCnf'.
        /// </summary>
        [XmlAttribute("EventOMMCertificateCnf")]
        public string EventOMMCertificateCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventOMPURLCnf'.
        /// </summary>
        [XmlAttribute("EventOMPURLCnf")]
        public string EventOMPURLCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventNetParamsCnf'.
        /// </summary>
        [XmlAttribute("EventNetParamsCnf")]
        public string EventNetParamsCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPARKCnf'.
        /// </summary>
        [XmlAttribute("EventPARKCnf")]
        public string EventPARKCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPARKFromServerResult'.
        /// </summary>
        [XmlAttribute("EventPARKFromServerResult")]
        public string EventPARKFromServerResult { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPBXEnrolmentCnf'.
        /// </summary>
        [XmlAttribute("EventPBXEnrolmentCnf")]
        public string EventPBXEnrolmentCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPermissionChange'.
        /// </summary>
        [XmlAttribute("EventPermissionChange")]
        public string EventPermissionChange { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPortRangeSIPCnf'.
        /// </summary>
        [XmlAttribute("EventPortRangeSIPCnf")]
        public string EventPortRangeSIPCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPositionHistory'.
        /// </summary>
        [XmlAttribute("EventPositionHistory")]
        public string EventPositionHistory { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPositionInfo'.
        /// </summary>
        [XmlAttribute("EventPositionInfo")]
        public string EventPositionInfo { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPositionRequest'.
        /// </summary>
        [XmlAttribute("EventPositionRequest")]
        public string EventPositionRequest { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPositionTrack'.
        /// </summary>
        [XmlAttribute("EventPositionTrack")]
        public string EventPositionTrack { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPpProfileCnf'.
        /// </summary>
        [XmlAttribute("EventPpProfileCnf")]
        public string EventPpProfileCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPPDevCnf'.
        /// </summary>
        [XmlAttribute("EventPPDevCnf")]
        public string EventPPDevCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPPDevSummary'.
        /// </summary>
        [XmlAttribute("EventPPDevSummary")]
        public string EventPPDevSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPPFirmwareUpdateCnf'.
        /// </summary>
        [XmlAttribute("EventPPFirmwareUpdateCnf")]
        public string EventPPFirmwareUpdateCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPPFirmwareUpdateOverview'.
        /// </summary>
        [XmlAttribute("EventPPFirmwareUpdateOverview")]
        public string EventPPFirmwareUpdateOverview { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPPFirmwareUpdateStatus'.
        /// </summary>
        [XmlAttribute("EventPPFirmwareUpdateStatus")]
        public string EventPPFirmwareUpdateStatus { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPPFirmwareURLCnf'.
        /// </summary>
        [XmlAttribute("EventPPFirmwareURLCnf")]
        public string EventPPFirmwareURLCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPPLoginVariantCnf'.
        /// </summary>
        [XmlAttribute("EventPPLoginVariantCnf")]
        public string EventPPLoginVariantCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPPState'.
        /// </summary>
        [XmlAttribute("EventPPState")]
        public string EventPPState { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPPTransaction'.
        /// </summary>
        [XmlAttribute("EventPPTransaction")]
        public string EventPPTransaction { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPPUserCnf'.
        /// </summary>
        [XmlAttribute("EventPPUserCnf")]
        public string EventPPUserCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPPUserSummary'.
        /// </summary>
        [XmlAttribute("EventPPUserSummary")]
        public string EventPPUserSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventPreserveUserDeviceRelationCnf'.
        /// </summary>
        [XmlAttribute("EventPreserveUserDeviceRelationCnf")]
        public string EventPreserveUserDeviceRelationCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventReadyForConferencing'.
        /// </summary>
        [XmlAttribute("EventReadyForConferencing")]
        public string EventReadyForConferencing { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRegistrationTrafficShapingCnf'.
        /// </summary>
        [XmlAttribute("EventRegistrationTrafficShapingCnf")]
        public string EventRegistrationTrafficShapingCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRemoteAccessCnf'.
        /// </summary>
        [XmlAttribute("EventRemoteAccessCnf")]
        public string EventRemoteAccessCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRemoteSystemDumpCnf'.
        /// </summary>
        [XmlAttribute("EventRemoteSystemDumpCnf")]
        public string EventRemoteSystemDumpCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRestrictedSubscriptionDurationCnf'.
        /// </summary>
        [XmlAttribute("EventRestrictedSubscriptionDurationCnf")]
        public string EventRestrictedSubscriptionDurationCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRFPCnf'.
        /// </summary>
        [XmlAttribute("EventRFPCnf")]
        public string EventRFPCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRFPCapture'.
        /// </summary>
        [XmlAttribute("EventRFPCapture")]
        public string EventRFPCapture { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRFPCaptureCnf'.
        /// </summary>
        [XmlAttribute("EventRFPCaptureCnf")]
        public string EventRFPCaptureCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRFPConnectAttempt'.
        /// </summary>
        [XmlAttribute("EventRFPConnectAttempt")]
        public string EventRFPConnectAttempt { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRFPDetails'.
        /// </summary>
        [XmlAttribute("EventRFPDetails")]
        public string EventRFPDetails { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRFPIpQuality'.
        /// </summary>
        [XmlAttribute("EventRFPIpQuality")]
        public string EventRFPIpQuality { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRFPMCnf'.
        /// </summary>
        [XmlAttribute("EventRFPMCnf")]
        public string EventRFPMCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRFPMediaStreamQuality'.
        /// </summary>
        [XmlAttribute("EventRFPMediaStreamQuality")]
        public string EventRFPMediaStreamQuality { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRFPState'.
        /// </summary>
        [XmlAttribute("EventRFPState")]
        public string EventRFPState { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRFPSummary'.
        /// </summary>
        [XmlAttribute("EventRFPSummary")]
        public string EventRFPSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRFPSyncQuality'.
        /// </summary>
        [XmlAttribute("EventRFPSyncQuality")]
        public string EventRFPSyncQuality { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRFPSyncRel'.
        /// </summary>
        [XmlAttribute("EventRFPSyncRel")]
        public string EventRFPSyncRel { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRTPCnf'.
        /// </summary>
        [XmlAttribute("EventRTPCnf")]
        public string EventRTPCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventRTPConferenceStreamChg'.
        /// </summary>
        [XmlAttribute("EventRTPConferenceStreamChg")]
        public string EventRTPConferenceStreamChg { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSARICnf'.
        /// </summary>
        [XmlAttribute("EventSARICnf")]
        public string EventSARICnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSecureOMMCertificateServerImportCnf'.
        /// </summary>
        [XmlAttribute("EventSecureOMMCertificateServerImportCnf")]
        public string EventSecureOMMCertificateServerImportCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSecurePROVCertificateServerImportCnf'.
        /// </summary>
        [XmlAttribute("EventSecurePROVCertificateServerImportCnf")]
        public string EventSecurePROVCertificateServerImportCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSecureSIPCertificateCnf'.
        /// </summary>
        [XmlAttribute("EventSecureSIPCertificateCnf")]
        public string EventSecureSIPCertificateCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSecureSIPCertificateServerImportCnf'.
        /// </summary>
        [XmlAttribute("EventSecureSIPCertificateServerImportCnf")]
        public string EventSecureSIPCertificateServerImportCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSecureSIPCnf'.
        /// </summary>
        [XmlAttribute("EventSecureSIPCnf")]
        public string EventSecureSIPCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSiteCnf'.
        /// </summary>
        [XmlAttribute("EventSiteCnf")]
        public string EventSiteCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSiteSummary'.
        /// </summary>
        [XmlAttribute("EventSiteSummary")]
        public string EventSiteSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSNMPCnf'.
        /// </summary>
        [XmlAttribute("EventSNMPCnf")]
        public string EventSNMPCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSoftwareImageURLCnf'.
        /// </summary>
        [XmlAttribute("EventSoftwareImageURLCnf")]
        public string EventSoftwareImageURLCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSpecialBrandingCnf'.
        /// </summary>
        [XmlAttribute("EventSpecialBrandingCnf")]
        public string EventSpecialBrandingCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventStbStateChange'.
        /// </summary>
        [XmlAttribute("EventStbStateChange")]
        public string EventStbStateChange { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSuplServCnf'.
        /// </summary>
        [XmlAttribute("EventSuplServCnf")]
        public string EventSuplServCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSyslogServerCnf'.
        /// </summary>
        [XmlAttribute("EventSyslogServerCnf")]
        public string EventSyslogServerCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSystemCredentialsCnf'.
        /// </summary>
        [XmlAttribute("EventSystemCredentialsCnf")]
        public string EventSystemCredentialsCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSystemNameCnf'.
        /// </summary>
        [XmlAttribute("EventSystemNameCnf")]
        public string EventSystemNameCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSystemProvUpdTrigCnf'.
        /// </summary>
        [XmlAttribute("EventSystemProvUpdTrigCnf")]
        public string EventSystemProvUpdTrigCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSysToneSchemeCnf'.
        /// </summary>
        [XmlAttribute("EventSysToneSchemeCnf")]
        public string EventSysToneSchemeCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventSysVoiceboxNumCnf'.
        /// </summary>
        [XmlAttribute("EventSysVoiceboxNumCnf")]
        public string EventSysVoiceboxNumCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventTimeZoneCnf'.
        /// </summary>
        [XmlAttribute("EventTimeZoneCnf")]
        public string EventTimeZoneCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventTimeZoneDetailsCnf'.
        /// </summary>
        [XmlAttribute("EventTimeZoneDetailsCnf")]
        public string EventTimeZoneDetailsCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventTimeZoneList'.
        /// </summary>
        [XmlAttribute("EventTimeZoneList")]
        public string EventTimeZoneList { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventUsedConfigURL'.
        /// </summary>
        [XmlAttribute("EventUsedConfigURL")]
        public string EventUsedConfigURL { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventUserDataImport'.
        /// </summary>
        [XmlAttribute("EventUserDataImport")]
        public string EventUserDataImport { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventUserDataServerCnf'.
        /// </summary>
        [XmlAttribute("EventUserDataServerCnf")]
        public string EventUserDataServerCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventUserDeviceSyncOMMCnf'.
        /// </summary>
        [XmlAttribute("EventUserDeviceSyncOMMCnf")]
        public string EventUserDeviceSyncOMMCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventUserMonitoringCnf'.
        /// </summary>
        [XmlAttribute("EventUserMonitoringCnf")]
        public string EventUserMonitoringCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventVideoDevCnf'.
        /// </summary>
        [XmlAttribute("EventVideoDevCnf")]
        public string EventVideoDevCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventVideoDevLink'.
        /// </summary>
        [XmlAttribute("EventVideoDevLink")]
        public string EventVideoDevLink { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventVideoDevSummary'.
        /// </summary>
        [XmlAttribute("EventVideoDevSummary")]
        public string EventVideoDevSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventWLANClient'.
        /// </summary>
        [XmlAttribute("EventWLANClient")]
        public string EventWLANClient { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventWLANProfileCnf'.
        /// </summary>
        [XmlAttribute("EventWLANProfileCnf")]
        public string EventWLANProfileCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventWLANRegDomainCnf'.
        /// </summary>
        [XmlAttribute("EventWLANRegDomainCnf")]
        public string EventWLANRegDomainCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘EventXMLApplicationCnf'.
        /// </summary>
        [XmlAttribute("EventXMLApplicationCnf")]
        public string EventXMLApplicationCnf { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GenerateHealthStateAlarmTriggers'.
        /// </summary>
        [XmlAttribute("GenerateHealthStateAlarmTriggers")]
        public string GenerateHealthStateAlarmTriggers { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetAccount'.
        /// </summary>
        [XmlAttribute("GetAccount")]
        public string GetAccount { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetAccountSummary'.
        /// </summary>
        [XmlAttribute("GetAccountSummary")]
        public string GetAccountSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetACLEntry'.
        /// </summary>
        [XmlAttribute("GetACLEntry")]
        public string GetACLEntry { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetActivePPDev'.
        /// </summary>
        [XmlAttribute("GetActivePPDev")]
        public string GetActivePPDev { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetAdvancedSIP'.
        /// </summary>
        [XmlAttribute("GetAdvancedSIP")]
        public string GetAdvancedSIP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetAlarmTrigger'.
        /// </summary>
        [XmlAttribute("GetAlarmTrigger")]
        public string GetAlarmTrigger { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetAlarmTriggerSummary'.
        /// </summary>
        [XmlAttribute("GetAlarmTriggerSummary")]
        public string GetAlarmTriggerSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetAutoDBBackup'.
        /// </summary>
        [XmlAttribute("GetAutoDBBackup")]
        public string GetAutoDBBackup { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetAutoDBBackupFileName'.
        /// </summary>
        [XmlAttribute("GetAutoDBBackupFileName")]
        public string GetAutoDBBackupFileName { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetBasicSIP'.
        /// </summary>
        [XmlAttribute("GetBasicSIP")]
        public string GetBasicSIP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetBackupSIP'.
        /// </summary>
        [XmlAttribute("GetBackupSIP")]
        public string GetBackupSIP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GettBluetoothClientStatistic'.
        /// </summary>
        [XmlAttribute("GettBluetoothClientStatistic")]
        public string GettBluetoothClientStatistic { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetBluetoothBeacon'.
        /// </summary>
        [XmlAttribute("GetBluetoothBeacon")]
        public string GetBluetoothBeacon { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetBluetoothBeaconSummary'.
        /// </summary>
        [XmlAttribute("GetBluetoothBeaconSummary")]
        public string GetBluetoothBeaconSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetBluetoothGlobalSettings'.
        /// </summary>
        [XmlAttribute("GetBluetoothGlobalSettings")]
        public string GetBluetoothGlobalSettings { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetBluetoothSensitivity'.
        /// </summary>
        [XmlAttribute("GetBluetoothSensitivity")]
        public string GetBluetoothSensitivity { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetConfigURL'.
        /// </summary>
        [XmlAttribute("GetConfigURL")]
        public string GetConfigURL { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetConferenceRoom'.
        /// </summary>
        [XmlAttribute("GetConferenceRoom")]
        public string GetConferenceRoom { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetConferenceServerSIP'.
        /// </summary>
        [XmlAttribute("GetConferenceServerSIP")]
        public string GetConferenceServerSIP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetCoreDumpURL'.
        /// </summary>
        [XmlAttribute("GetCoreDumpURL")]
        public string GetCoreDumpURL { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetDbTransferState'.
        /// </summary>
        [XmlAttribute("GetDbTransferState")]
        public string GetDbTransferState { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetDECTAuthCode'.
        /// </summary>
        [XmlAttribute("GetDECTAuthCode")]
        public string GetDECTAuthCode { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetDECTEncryption'.
        /// </summary>
        [XmlAttribute("GetDECTEncryption")]
        public string GetDECTEncryption { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetDECTPagingAreaSize'.
        /// </summary>
        [XmlAttribute("GetDECTPagingAreaSize")]
        public string GetDECTPagingAreaSize { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetDECTPowerLimit'.
        /// </summary>
        [XmlAttribute("GetDECTPowerLimit")]
        public string GetDECTPowerLimit { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetDECTPpSettings'.
        /// </summary>
        [XmlAttribute("GetDECTPpSettings")]
        public string GetDECTPpSettings { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetDECTRegDomain'.
        /// </summary>
        [XmlAttribute("GetDECTRegDomain")]
        public string GetDECTRegDomain { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetDECTSubscriptionMode'.
        /// </summary>
        [XmlAttribute("GetDECTSubscriptionMode")]
        public string GetDECTSubscriptionMode { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetDevAutoCreate'.
        /// </summary>
        [XmlAttribute("GetDevAutoCreate")]
        public string GetDevAutoCreate { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetDigitTreatment'.
        /// </summary>
        [XmlAttribute("GetDigitTreatment")]
        public string GetDigitTreatment { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetDigitTreatmentSummary'.
        /// </summary>
        [XmlAttribute("GetDigitTreatmentSummary")]
        public string GetDigitTreatmentSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetDTMF'.
        /// </summary>
        [XmlAttribute("GetDTMF")]
        public string GetDTMF { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetEULAConfirm'.
        /// </summary>
        [XmlAttribute("GetEULAConfirm")]
        public string GetEULAConfirm { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetEventLogBuffer'.
        /// </summary>
        [XmlAttribute("GetEventLogBuffer")]
        public string GetEventLogBuffer { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetFACList'.
        /// </summary>
        [XmlAttribute("GetFACList")]
        public string GetFACList { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetFACPrefix'.
        /// </summary>
        [XmlAttribute("GetFACPrefix")]
        public string GetFACPrefix { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetFile'.
        /// </summary>
        [XmlAttribute("GetFile")]
        public string GetFile { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetFlashMemUsage'.
        /// </summary>
        [XmlAttribute("GetFlashMemUsage")]
        public string GetFlashMemUsage { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetFreeConferenceChannels'.
        /// </summary>
        [XmlAttribute("GetFreeConferenceChannels")]
        public string GetFreeConferenceChannels { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetG729ChannelsForConference'.
        /// </summary>
        [XmlAttribute("GetG729ChannelsForConference")]
        public string GetG729ChannelsForConference { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetHealthState'.
        /// </summary>
        [XmlAttribute("GetHealthState")]
        public string GetHealthState { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetIMA'.
        /// </summary>
        [XmlAttribute("GetIMA")]
        public string GetIMA { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetIntercomCallHandlingSIP'.
        /// </summary>
        [XmlAttribute("GetIntercomCallHandlingSIP")]
        public string GetIntercomCallHandlingSIP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetLastPPDevAction'.
        /// </summary>
        [XmlAttribute("GetLastPPDevAction")]
        public string GetLastPPDevAction { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetLDAP'.
        /// </summary>
        [XmlAttribute("GetLDAP")]
        public string GetLDAP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetLicense'.
        /// </summary>
        [XmlAttribute("GetLicense")]
        public string GetLicense { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetLicenseServerList'.
        /// </summary>
        [XmlAttribute("GetLicenseServerList")]
        public string GetLicenseServerList { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetLicensedCodecLines'.
        /// </summary>
        [XmlAttribute("GetLicensedCodecLines")]
        public string GetLicensedCodecLines { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetNetParams'.
        /// </summary>
        [XmlAttribute("GetNetParams")]
        public string GetNetParams { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetOMMCertificate'.
        /// </summary>
        [XmlAttribute("GetOMMCertificate")]
        public string GetOMMCertificate { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetOMPURL'.
        /// </summary>
        [XmlAttribute("GetOMPURL")]
        public string GetOMPURL { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetNTPServer'.
        /// </summary>
        [XmlAttribute("GetNTPServer")]
        public string GetNTPServer { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPARK'.
        /// </summary>
        [XmlAttribute("GetPARK")]
        public string GetPARK { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPBXEnrolment'.
        /// </summary>
        [XmlAttribute("GetPBXEnrolment")]
        public string GetPBXEnrolment { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPortRangeSIP'.
        /// </summary>
        [XmlAttribute("GetPortRangeSIP")]
        public string GetPortRangeSIP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPpProfile'.
        /// </summary>
        [XmlAttribute("GetPpProfile")]
        public string GetPpProfile { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPPDev'.
        /// </summary>
        [XmlAttribute("GetPPDev")]
        public string GetPPDev { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPPDevSummary'.
        /// </summary>
        [XmlAttribute("GetPPDevSummary")]
        public string GetPPDevSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPPFirmwareUpdate'.
        /// </summary>
        [XmlAttribute("GetPPFirmwareUpdate")]
        public string GetPPFirmwareUpdate { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPPFirmwareUpdateOverview'.
        /// </summary>
        [XmlAttribute("GetPPFirmwareUpdateOverview")]
        public string GetPPFirmwareUpdateOverview { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPPFirmwareUpdateStatus'.
        /// </summary>
        [XmlAttribute("GetPPFirmwareUpdateStatus")]
        public string GetPPFirmwareUpdateStatus { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPPFirmwareURL'.
        /// </summary>
        [XmlAttribute("GetPPFirmwareURL")]
        public string GetPPFirmwareURL { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPPLoginVariant'.
        /// </summary>
        [XmlAttribute("GetPPLoginVariant")]
        public string GetPPLoginVariant { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPPState'.
        /// </summary>
        [XmlAttribute("GetPPState")]
        public string GetPPState { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPPUser'.
        /// </summary>
        [XmlAttribute("GetPPUser")]
        public string GetPPUser { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPPUserSummary'.
        /// </summary>
        [XmlAttribute("GetPPUserSummary")]
        public string GetPPUserSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPreserveUserDeviceRelation'.
        /// </summary>
        [XmlAttribute("GetPreserveUserDeviceRelation")]
        public string GetPreserveUserDeviceRelation { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetPublicKey'.
        /// </summary>
        [XmlAttribute("GetPublicKey")]
        public string GetPublicKey { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetReadyForConferencing'.
        /// </summary>
        [XmlAttribute("GetReadyForConferencing")]
        public string GetReadyForConferencing { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRegistrationTrafficShaping'.
        /// </summary>
        [XmlAttribute("GetRegistrationTrafficShaping")]
        public string GetRegistrationTrafficShaping { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRemoteAccess'.
        /// </summary>
        [XmlAttribute("GetRemoteAccess")]
        public string GetRemoteAccess { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRemoteSystemDump'.
        /// </summary>
        [XmlAttribute("GetRemoteSystemDump")]
        public string GetRemoteSystemDump { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRestrictedSubscriptionDuration'.
        /// </summary>
        [XmlAttribute("GetRestrictedSubscriptionDuration")]
        public string GetRestrictedSubscriptionDuration { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRFP'.
        /// </summary>
        [XmlAttribute("GetRFP")]
        public string GetRFP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRFPCapture'.
        /// </summary>
        [XmlAttribute("GetRFPCapture")]
        public string GetRFPCapture { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRFPCaptureList'.
        /// </summary>
        [XmlAttribute("GetRFPCaptureList")]
        public string GetRFPCaptureList { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRFPIpQuality'.
        /// </summary>
        [XmlAttribute("GetRFPIpQuality")]
        public string GetRFPIpQuality { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRFPM'.
        /// </summary>
        [XmlAttribute("GetRFPM")]
        public string GetRFPM { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRFPMediaStreamQuality'.
        /// </summary>
        [XmlAttribute("GetRFPMediaStreamQuality")]
        public string GetRFPMediaStreamQuality { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRFPStatistic'.
        /// </summary>
        [XmlAttribute("GetRFPStatistic")]
        public string GetRFPStatistic { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRFPStatisticConfig'.
        /// </summary>
        [XmlAttribute("GetRFPStatisticConfig")]
        public string GetRFPStatisticConfig { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRFPSummary'.
        /// </summary>
        [XmlAttribute("GetRFPSummary")]
        public string GetRFPSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRFPSync'.
        /// </summary>
        [XmlAttribute("GetRFPSync")]
        public string GetRFPSync { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRFPSyncQuality'.
        /// </summary>
        [XmlAttribute("GetRFPSyncQuality")]
        public string GetRFPSyncQuality { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetRTP'.
        /// </summary>
        [XmlAttribute("GetRTP")]
        public string GetRTP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSARI'.
        /// </summary>
        [XmlAttribute("GetSARI")]
        public string GetSARI { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSecureSIP'.
        /// </summary>
        [XmlAttribute("GetSecureSIP")]
        public string GetSecureSIP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSecureOMMCertificateServerImport'.
        /// </summary>
        [XmlAttribute("GetSecureOMMCertificateServerImport")]
        public string GetSecureOMMCertificateServerImport { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSecurePROVCertificateServerImport'.
        /// </summary>
        [XmlAttribute("GetSecurePROVCertificateServerImport")]
        public string GetSecurePROVCertificateServerImport { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSecureSIPCertificate'.
        /// </summary>
        [XmlAttribute("GetSecureSIPCertificate")]
        public string GetSecureSIPCertificate { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSecureSIPCertificateServerImport'.
        /// </summary>
        [XmlAttribute("GetSecureSIPCertificateServerImport")]
        public string GetSecureSIPCertificateServerImport { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSite'.
        /// </summary>
        [XmlAttribute("GetSite")]
        public string GetSite { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSiteSummary'.
        /// </summary>
        [XmlAttribute("GetSiteSummary")]
        public string GetSiteSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSNMP'.
        /// </summary>
        [XmlAttribute("GetSNMP")]
        public string GetSNMP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSoftwareImageURL'.
        /// </summary>
        [XmlAttribute("GetSoftwareImageURL")]
        public string GetSoftwareImageURL { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSpecialBranding'.
        /// </summary>
        [XmlAttribute("GetSpecialBranding")]
        public string GetSpecialBranding { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetStbState'.
        /// </summary>
        [XmlAttribute("GetStbState")]
        public string GetStbState { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSuplServ'.
        /// </summary>
        [XmlAttribute("GetSuplServ")]
        public string GetSuplServ { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSyslogServer'.
        /// </summary>
        [XmlAttribute("GetSyslogServer")]
        public string GetSyslogServer { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSysStatisticConfig'.
        /// </summary>
        [XmlAttribute("GetSysStatisticConfig")]
        public string GetSysStatisticConfig { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSysStatisticMinMax'.
        /// </summary>
        [XmlAttribute("GetSysStatisticMinMax")]
        public string GetSysStatisticMinMax { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSysStatisticMinMaxRecord'.
        /// </summary>
        [XmlAttribute("GetSysStatisticMinMaxRecord")]
        public string GetSysStatisticMinMaxRecord { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSysStatisticMinMaxSummary'.
        /// </summary>
        [XmlAttribute("GetSysStatisticMinMaxSummary")]
        public string GetSysStatisticMinMaxSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSysStatisticOccurrence'.
        /// </summary>
        [XmlAttribute("GetSysStatisticOccurrence")]
        public string GetSysStatisticOccurrence { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSystemCredentials'.
        /// </summary>
        [XmlAttribute("GetSystemCredentials")]
        public string GetSystemCredentials { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSystemName'.
        /// </summary>
        [XmlAttribute("GetSystemName")]
        public string GetSystemName { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSystemProvUpdTrig'.
        /// </summary>
        [XmlAttribute("GetSystemProvUpdTrig")]
        public string GetSystemProvUpdTrig { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSysToneScheme'.
        /// </summary>
        [XmlAttribute("GetSysToneScheme")]
        public string GetSysToneScheme { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetSysVoiceboxNum'.
        /// </summary>
        [XmlAttribute("GetSysVoiceboxNum")]
        public string GetSysVoiceboxNum { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetTimeZone'.
        /// </summary>
        [XmlAttribute("GetTimeZone")]
        public string GetTimeZone { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetTimeZoneDetails'.
        /// </summary>
        [XmlAttribute("GetTimeZoneDetails")]
        public string GetTimeZoneDetails { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetTimeZoneList'.
        /// </summary>
        [XmlAttribute("GetTimeZoneList")]
        public string GetTimeZoneList { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetUsedConfigURL'.
        /// </summary>
        [XmlAttribute("GetUsedConfigURL")]
        public string GetUsedConfigURL { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetUserDataServer'.
        /// </summary>
        [XmlAttribute("GetUserDataServer")]
        public string GetUserDataServer { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetUserDeviceSyncOMM'.
        /// </summary>
        [XmlAttribute("GetUserDeviceSyncOMM")]
        public string GetUserDeviceSyncOMM { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetUserMonitoring'.
        /// </summary>
        [XmlAttribute("GetUserMonitoring")]
        public string GetUserMonitoring { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetVersions'.
        /// </summary>
        [XmlAttribute("GetVersions")]
        public string GetVersions { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetVideoDev'.
        /// </summary>
        [XmlAttribute("GetVideoDev")]
        public string GetVideoDev { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetVideoDevLink'.
        /// </summary>
        [XmlAttribute("GetVideoDevLink")]
        public string GetVideoDevLink { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetVideoDevSummary'.
        /// </summary>
        [XmlAttribute("GetVideoDevSummary")]
        public string GetVideoDevSummary { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetWLANClients'.
        /// </summary>
        [XmlAttribute("GetWLANClients")]
        public string GetWLANClients { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetWLANProfile'.
        /// </summary>
        [XmlAttribute("GetWLANProfile")]
        public string GetWLANProfile { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetWLANRegDomain'.
        /// </summary>
        [XmlAttribute("GetWLANRegDomain")]
        public string GetWLANRegDomain { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetWLANRegDomainList'.
        /// </summary>
        [XmlAttribute("GetWLANRegDomainList")]
        public string GetWLANRegDomainList { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘GetXMLApplication'.
        /// </summary>
        [XmlAttribute("GetXMLApplication")]
        public string GetXMLApplication { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘Limits'.
        /// </summary>
        [XmlAttribute("Limits")]
        public string Limits { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘ManualDBBackup'.
        /// </summary>
        [XmlAttribute("ManualDBBackup")]
        public string ManualDBBackup { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘ManualDBRestore'.
        /// </summary>
        [XmlAttribute("ManualDBRestore")]
        public string ManualDBRestore { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘ManualUserDataImport'.
        /// </summary>
        [XmlAttribute("ManualUserDataImport")]
        public string ManualUserDataImport { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘Open'.
        /// </summary>
        [XmlAttribute("Open")]
        public string Open { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘PARKFromServer'.
        /// </summary>
        [XmlAttribute("PARKFromServer")]
        public string PARKFromServer { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘Ping'.
        /// </summary>
        [XmlAttribute("Ping")]
        public string Ping { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘PutFile'.
        /// </summary>
        [XmlAttribute("PutFile")]
        public string PutFile { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘RequestPositionInfo'.
        /// </summary>
        [XmlAttribute("RequestPositionInfo")]
        public string RequestPositionInfo { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘ResetRFPMediaStreamQuality'.
        /// </summary>
        [XmlAttribute("ResetRFPMediaStreamQuality")]
        public string ResetRFPMediaStreamQuality { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘ResetRFPStatistic'.
        /// </summary>
        [XmlAttribute("ResetRFPStatistic")]
        public string ResetRFPStatistic { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘ResetSysStatistic'.
        /// </summary>
        [XmlAttribute("ResetSysStatistic")]
        public string ResetSysStatistic { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘ResetTimeZoneDetails'.
        /// </summary>
        [XmlAttribute("ResetTimeZoneDetails")]
        public string ResetTimeZoneDetails { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SendMessage'.
        /// </summary>
        [XmlAttribute("SendMessage")]
        public string SendMessage { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetAccount'.
        /// </summary>
        [XmlAttribute("SetAccount")]
        public string SetAccount { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetACLEntry'.
        /// </summary>
        [XmlAttribute("SetACLEntry")]
        public string SetACLEntry { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetAdvancedSIP'.
        /// </summary>
        [XmlAttribute("SetAdvancedSIP")]
        public string SetAdvancedSIP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetAlarmTrigger'.
        /// </summary>
        [XmlAttribute("SetAlarmTrigger")]
        public string SetAlarmTrigger { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetAutoDBBackup'.
        /// </summary>
        [XmlAttribute("SetAutoDBBackup")]
        public string SetAutoDBBackup { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetBasicSIP'.
        /// </summary>
        [XmlAttribute("SetBasicSIP")]
        public string SetBasicSIP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetBackupSIP'.
        /// </summary>
        [XmlAttribute("SetBackupSIP")]
        public string SetBackupSIP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetBluetoothBeacon'.
        /// </summary>
        [XmlAttribute("SetBluetoothBeacon")]
        public string SetBluetoothBeacon { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetBluetoothGlobalSettings'.
        /// </summary>
        [XmlAttribute("SetBluetoothGlobalSettings")]
        public string SetBluetoothGlobalSettings { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetBluetoothSensitivity'.
        /// </summary>
        [XmlAttribute("SetBluetoothSensitivity")]
        public string SetBluetoothSensitivity { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetConferenceRoom'.
        /// </summary>
        [XmlAttribute("SetConferenceRoom")]
        public string SetConferenceRoom { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetConferenceServerSIP'.
        /// </summary>
        [XmlAttribute("SetConferenceServerSIP")]
        public string SetConferenceServerSIP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetConfigURL'.
        /// </summary>
        [XmlAttribute("SetConfigURL")]
        public string SetConfigURL { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetCoreDumpURL'.
        /// </summary>
        [XmlAttribute("SetCoreDumpURL")]
        public string SetCoreDumpURL { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetDECTAuthCode'.
        /// </summary>
        [XmlAttribute("SetDECTAuthCode")]
        public string SetDECTAuthCode { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetDECTEncryption'.
        /// </summary>
        [XmlAttribute("SetDECTEncryption")]
        public string SetDECTEncryption { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetDECTPagingAreaSize'.
        /// </summary>
        [XmlAttribute("SetDECTPagingAreaSize")]
        public string SetDECTPagingAreaSize { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetDECTPowerLimit'.
        /// </summary>
        [XmlAttribute("SetDECTPowerLimit")]
        public string SetDECTPowerLimit { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetDECTPpSettings'.
        /// </summary>
        [XmlAttribute("SetDECTPpSettings")]
        public string SetDECTPpSettings { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetDECTRegDomain'.
        /// </summary>
        [XmlAttribute("SetDECTRegDomain")]
        public string SetDECTRegDomain { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetDECTSubscriptionMode'.
        /// </summary>
        [XmlAttribute("SetDECTSubscriptionMode")]
        public string SetDECTSubscriptionMode { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetDevAutoCreate'.
        /// </summary>
        [XmlAttribute("SetDevAutoCreate")]
        public string SetDevAutoCreate { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetDigitTreatment'.
        /// </summary>
        [XmlAttribute("SetDigitTreatment")]
        public string SetDigitTreatment { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetDTMF'.
        /// </summary>
        [XmlAttribute("SetDTMF")]
        public string SetDTMF { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetEULAConfirm'.
        /// </summary>
        [XmlAttribute("SetEULAConfirm")]
        public string SetEULAConfirm { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetFAC'.
        /// </summary>
        [XmlAttribute("SetFAC")]
        public string SetFAC { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetFACList'.
        /// </summary>
        [XmlAttribute("SetFACList")]
        public string SetFACList { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetFACPrefix'.
        /// </summary>
        [XmlAttribute("SetFACPrefix")]
        public string SetFACPrefix { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetIMA'.
        /// </summary>
        [XmlAttribute("SetIMA")]
        public string SetIMA { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetIntercomCallHandlingSIP'.
        /// </summary>
        [XmlAttribute("SetIntercomCallHandlingSIP")]
        public string SetIntercomCallHandlingSIP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetLDAP'.
        /// </summary>
        [XmlAttribute("SetLDAP")]
        public string SetLDAP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetLicenseServerList'.
        /// </summary>
        [XmlAttribute("SetLicenseServerList")]
        public string SetLicenseServerList { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetNetParams'.
        /// </summary>
        [XmlAttribute("SetNetParams")]
        public string SetNetParams { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetOMMCertificate'.
        /// </summary>
        [XmlAttribute("SetOMMCertificate")]
        public string SetOMMCertificate { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetOMPURL'.
        /// </summary>
        [XmlAttribute("SetOMPURL")]
        public string SetOMPURL { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetNTPServer'.
        /// </summary>
        [XmlAttribute("SetNTPServer")]
        public string SetNTPServer { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetPARK'.
        /// </summary>
        [XmlAttribute("SetPARK")]
        public string SetPARK { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetPBXEnrolment'.
        /// </summary>
        [XmlAttribute("SetPBXEnrolment")]
        public string SetPBXEnrolment { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetPortRangeSIP'.
        /// </summary>
        [XmlAttribute("SetPortRangeSIP")]
        public string SetPortRangeSIP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetPpProfile'.
        /// </summary>
        [XmlAttribute("SetPpProfile")]
        public string SetPpProfile { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetPPDev'.
        /// </summary>
        [XmlAttribute("SetPPDev")]
        public string SetPPDev { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetPPFirmwareUpdate'.
        /// </summary>
        [XmlAttribute("SetPPFirmwareUpdate")]
        public string SetPPFirmwareUpdate { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetPPFirmwareURL'.
        /// </summary>
        [XmlAttribute("SetPPFirmwareURL")]
        public string SetPPFirmwareURL { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetPPLoginVariant'.
        /// </summary>
        [XmlAttribute("SetPPLoginVariant")]
        public string SetPPLoginVariant { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetPPUser'.
        /// </summary>
        [XmlAttribute("SetPPUser")]
        public string SetPPUser { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetPPUserDevRelation'.
        /// </summary>
        [XmlAttribute("SetPPUserDevRelation")]
        public string SetPPUserDevRelation { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetPPUserTracking'.
        /// </summary>
        [XmlAttribute("SetPPUserTracking")]
        public string SetPPUserTracking { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetPreserveUserDeviceRelation'.
        /// </summary>
        [XmlAttribute("SetPreserveUserDeviceRelation")]
        public string SetPreserveUserDeviceRelation { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetRegistrationTrafficShaping'.
        /// </summary>
        [XmlAttribute("SetRegistrationTrafficShaping")]
        public string SetRegistrationTrafficShaping { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetRemoteAccess'.
        /// </summary>
        [XmlAttribute("SetRemoteAccess")]
        public string SetRemoteAccess { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetRemoteSystemDump'.
        /// </summary>
        [XmlAttribute("SetRemoteSystemDump")]
        public string SetRemoteSystemDump { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetRestrictedSubscriptionDuration'.
        /// </summary>
        [XmlAttribute("SetRestrictedSubscriptionDuration")]
        public string SetRestrictedSubscriptionDuration { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetRFP'.
        /// </summary>
        [XmlAttribute("SetRFP")]
        public string SetRFP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetRFPCapture'.
        /// </summary>
        [XmlAttribute("SetRFPCapture")]
        public string SetRFPCapture { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetRFPM'.
        /// </summary>
        [XmlAttribute("SetRFPM")]
        public string SetRFPM { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetRTP'.
        /// </summary>
        [XmlAttribute("SetRTP")]
        public string SetRTP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetRTPConferenceStreamChg'.
        /// </summary>
        [XmlAttribute("SetRTPConferenceStreamChg")]
        public string SetRTPConferenceStreamChg { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSARI'.
        /// </summary>
        [XmlAttribute("SetSARI")]
        public string SetSARI { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSecureSIP'.
        /// </summary>
        [XmlAttribute("SetSecureSIP")]
        public string SetSecureSIP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSecureOMMCertificateServerImport'.
        /// </summary>
        [XmlAttribute("SetSecureOMMCertificateServerImport")]
        public string SetSecureOMMCertificateServerImport { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSecurePROVCertificateServerImport'.
        /// </summary>
        [XmlAttribute("SetSecurePROVCertificateServerImport")]
        public string SetSecurePROVCertificateServerImport { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSecureSIPCertificate'.
        /// </summary>
        [XmlAttribute("SetSecureSIPCertificate")]
        public string SetSecureSIPCertificate { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSecureSIPCertificateServerImport'.
        /// </summary>
        [XmlAttribute("SetSecureSIPCertificateServerImport")]
        public string SetSecureSIPCertificateServerImport { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSite'.
        /// </summary>
        [XmlAttribute("SetSite")]
        public string SetSite { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSNMP'.
        /// </summary>
        [XmlAttribute("SetSNMP")]
        public string SetSNMP { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSoftwareImageURL'.
        /// </summary>
        [XmlAttribute("SetSoftwareImageURL")]
        public string SetSoftwareImageURL { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSpecialBranding'.
        /// </summary>
        [XmlAttribute("SetSpecialBranding")]
        public string SetSpecialBranding { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSuplServ'.
        /// </summary>
        [XmlAttribute("SetSuplServ")]
        public string SetSuplServ { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSyslogServer'.
        /// </summary>
        [XmlAttribute("SetSyslogServer")]
        public string SetSyslogServer { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSystemCredentials'.
        /// </summary>
        [XmlAttribute("SetSystemCredentials")]
        public string SetSystemCredentials { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSystemName'.
        /// </summary>
        [XmlAttribute("SetSystemName")]
        public string SetSystemName { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSystemProvUpdTrig'.
        /// </summary>
        [XmlAttribute("SetSystemProvUpdTrig")]
        public string SetSystemProvUpdTrig { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSysToneScheme'.
        /// </summary>
        [XmlAttribute("SetSysToneScheme")]
        public string SetSysToneScheme { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetSysVoiceboxNum'.
        /// </summary>
        [XmlAttribute("SetSysVoiceboxNum")]
        public string SetSysVoiceboxNum { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetTimeZone'.
        /// </summary>
        [XmlAttribute("SetTimeZone")]
        public string SetTimeZone { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetTimeZoneDetails'.
        /// </summary>
        [XmlAttribute("SetTimeZoneDetails")]
        public string SetTimeZoneDetails { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetUserDataServer'.
        /// </summary>
        [XmlAttribute("SetUserDataServer")]
        public string SetUserDataServer { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetUserDeviceSyncOMM'.
        /// </summary>
        [XmlAttribute("SetUserDeviceSyncOMM")]
        public string SetUserDeviceSyncOMM { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetUserMonitoring'.
        /// </summary>
        [XmlAttribute("SetUserMonitoring")]
        public string SetUserMonitoring { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetVideoDev'.
        /// </summary>
        [XmlAttribute("SetVideoDev")]
        public string SetVideoDev { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetWLANProfile'.
        /// </summary>
        [XmlAttribute("SetWLANProfile")]
        public string SetWLANProfile { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetWLANRegDomain'.
        /// </summary>
        [XmlAttribute("SetWLANRegDomain")]
        public string SetWLANRegDomain { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SetXMLApplication'.
        /// </summary>
        [XmlAttribute("SetXMLApplication")]
        public string SetXMLApplication { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SoftwareUpate'.
        /// </summary>
        [XmlAttribute("SoftwareUpate")]
        public string SoftwareUpate { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘Subscribe'.
        /// </summary>
        [XmlAttribute("Subscribe")]
        public string Subscribe { get; set; }

        /// <summary>
        /// Version string of the request/response elements ‘SystemRestart'.
        /// </summary>
        [XmlAttribute("SystemRestart")]
        public string SystemRestart { get; set; }
    }
}