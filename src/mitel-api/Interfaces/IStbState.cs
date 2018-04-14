using mitelapi.Types;

namespace mitelapi.Interfaces
{
    public interface IStbState
    {
        /// <summary>
        /// State of the OMM standby feature.
        /// </summary>
        OmmStbState StandbyState { get; set; }

        /// <summary>
        /// In case of OMM standby is active: IP address of the other OMM
        /// </summary>
        string StandbyAddress { get; set; }
    }
}