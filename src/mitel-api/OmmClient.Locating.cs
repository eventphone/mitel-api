using System.Threading;
using System.Threading.Tasks;
using mitelapi.Messages;

namespace mitelapi
{
    public partial class OmmClient
    {
        /// <summary>
        /// With this request a client can locate a DECT phone.
        /// </summary>
        /// <param name="ppn">PPN of DECT phone to be found</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task RequestPositionInfoAsync(int ppn, CancellationToken cancellationToken)
        {
            var request = new RequestPositionInfo {Ppn = ppn};
            return SendAsync<RequestPositionInfo, RequestPositionInfoResp>(request, cancellationToken);
        }

        /// <summary>
        /// The client can send this request to OM AXI to change the attribute trackingActive of a DECT phone user data set.
        /// </summary>
        /// <param name="uid">The User ID (uid) has to be filled in by the client to identify the record to be changed.</param>
        /// <param name="active">„1” or “true”, if the location of this user has to be tracked</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task SetPPUserTrackingAsync(int uid, bool active, CancellationToken cancellationToken)
        {
            var request = new SetPPUserTracking {Uid = uid, TrackingActive = active};
            return SendAsync<SetPPUserTracking, SetPPUserTrackingResp>(request, cancellationToken);
        }
    }
}