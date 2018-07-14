using mitelapi.Types;

namespace mitelapi.Interfaces
{
    public interface ILicenseCnf
    {
        /// <summary>
        /// Type of license
        /// </summary>
        LicenseSize Type { get; set; }

        /// <summary>
        /// State of any license violation.
        /// <remarks>
        /// <para>
        /// In the license non violated state <see cref="LicenseViolation.NoLicense"/> or <see cref="LicenseViolation.ActiveLicense"/> the <see cref="Latency"/> counter counts up, otherwise it counts down until to the maximum value of 43200 minutes (30 days).
        /// </para>
        /// </remarks>
        /// </summary>
        LicenseViolation State { get; set; }

        /// <summary>
        /// License violation reasons, when the <see cref="State"/> is not <see cref="LicenseViolation.NoLicense"/> and not <see cref="LicenseViolation.ActiveLicense"/>.
        /// </summary>
        LicenseViolationReason[] Violation { get; set; }

        /// <summary>
        /// Grace period time value in minutes, how long the system will work with a violated license
        /// </summary>
        int Latency { get; set; }

        /// <summary>
        /// PARK for the license keys.
        /// </summary>
        string Park { get; set; }

        /// <summary>
        /// Up to three data sets for license RFPs
        /// </summary>
        LicenseRFPType[] LicenseRFPs { get; set; }

        /// <summary>
        /// OMM system license.
        /// </summary>
        SysLicenseType SysLicense { get; set; }

        /// <summary>
        /// OMM messaging license.
        /// </summary>
        MsgLicenseType MsgLicense { get; set; }

        /// <summary>
        /// OMM locating license.
        /// </summary>
        LocLicenseType LocLicense { get; set; }
    }
}