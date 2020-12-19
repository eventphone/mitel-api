using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using mitelapi.Messages;
using mitelapi.Types;

namespace mitelapi
{
    public partial class OmmClient
    {
        public async Task<bool> GetRFPCaptureAsync(CancellationToken cancellationToken)
        {
            var resp = await SendAsync<GetRFPCapture, GetRFPCaptureResp>(new GetRFPCapture(), cancellationToken).ConfigureAwait(false);
            return resp.Enable;
        }

        public async Task<DeleteRFPCaptureListElemResp> DeleteRFPCaptureListElemAsync(string mac, CancellationToken cancellationToken)
        {
            return await SendAsync<DeleteRFPCaptureListElem, DeleteRFPCaptureListElemResp>(new DeleteRFPCaptureListElem() {EthAddr = mac }, cancellationToken).ConfigureAwait(false);
        }

        public async Task<DeleteRFPCaptureListResp> DeleteRFPCaptureListAsync(CancellationToken cancellationToken)
        {
            return await SendAsync<DeleteRFPCaptureList, DeleteRFPCaptureListResp>(new DeleteRFPCaptureList(), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SetRFPCaptureResp> SetRFPCaptureAsync(bool enabled, CancellationToken cancellationToken)
        {
            return await SendAsync<SetRFPCapture, SetRFPCaptureResp>(new SetRFPCapture() { Enable = enabled }, cancellationToken).ConfigureAwait(false);
        }

        public async Task<GetRFPCaptureListResp> GetRFPCaptureListAsync(CancellationToken cancellationToken)
        {
            return await SendAsync<GetRFPCaptureList, GetRFPCaptureListResp>(new GetRFPCaptureList(), cancellationToken).ConfigureAwait(false);
        }

        public async Task<GetRFPSyncResp> GetRFPSyncAsync(int id, CancellationToken cancellationToken)
        {
            return await SendAsync<GetRFPSync, GetRFPSyncResp>(new GetRFPSync { Id = id }, cancellationToken).ConfigureAwait(false);
        }

        public async Task<GetRFPSyncQualityResp> GetRFPSyncQualityAsync(int id, int maxRecords, CancellationToken cancellationToken)
        {
            return await SendAsync<GetRFPSyncQuality, GetRFPSyncQualityResp>(new GetRFPSyncQuality { Id = id, MaxRecords = maxRecords }, cancellationToken).ConfigureAwait(false);
        }

        public async Task<RFPType> GetRFPAsync(int id, bool withDetails, bool withState, CancellationToken cancellationToken)
        {
            var response = await SendAsync<GetRFP, GetRFPResp>(new GetRFP { Id = id, WithDetails=withDetails, WithState=withState, MaxRecords=1 }, cancellationToken).ConfigureAwait(false);
            return response.RFPs[0];
        }

        public async Task SetRFPAsync(RFPType rfp, CancellationToken cancellationToken)
        {
            await SendAsync<SetRFP, SetRFPResp>(new SetRFP { Rfp = rfp}, cancellationToken).ConfigureAwait(false);
        }

        public async Task DeleteRFPAsync(int id, CancellationToken cancellationToken)
        {
            await SendAsync<DeleteRFP, DeleteRFPResp>(new DeleteRFP { Id = id }, cancellationToken).ConfigureAwait(false);
        }

        public async Task CreateRFPAsync(RFPType rfp, CancellationToken cancellationToken)
        {
            await SendAsync<CreateRFP, CreateRFPResp>(new CreateRFP { Rfp = rfp }, cancellationToken).ConfigureAwait(false);
        }

        public async Task<List<RFPType>> GetRFPAllAsync(bool withDetails, bool withState, CancellationToken cancellationToken)
        {
            var id = 0;
            var result = new List<RFPType>();
            while (true)
            {
                try
                {
                    var rfps = await SendAsync<GetRFP, GetRFPResp>(new GetRFP { Id = id, MaxRecords = 20, WithDetails=withDetails, WithState=withState }, cancellationToken).ConfigureAwait(false);
                    id = rfps.RFPs.Max(x => x.Id.GetValueOrDefault()) + 1;
                    foreach (var rfp in rfps.RFPs)
                    {
                        result.Add(rfp);
                    }
                }
                catch (OmmNoEntryException)
                {
                    break;
                }
            }
            return result;
        }

        public async Task<GetRFPStatisticConfigResp> GetRFPStatisticConfigAsync(CancellationToken cancellationToken)
        {
            var response = await SendAsync<GetRFPStatisticConfig, GetRFPStatisticConfigResp>(new GetRFPStatisticConfig(), cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// With this request the client can query the statistic counter of an RFP.
        /// </summary>
        /// <param name="id">Unique RFP identifier. The numbering starts at 0</param>
        /// <param name="maxRecord">Maximal number of records to return. Not more than 20 allowed.
        /// If maxRecord is equal 0, only the record of the RFP addressed by id should be fetched</param>
        /// <param name="recordSet">Record set to read
        /// Record 0 identifies the overall counter, 1 the current week, 2 the week before the current week and so on.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<GetRFPStatisticResp> GetRFPStatisticAsync(int id, int maxRecord, int recordSet, CancellationToken cancellationToken)
        {
            var request = new GetRFPStatistic {Id = id, MaxRecords = maxRecord, RecordSet = recordSet};
            return GetRFPStatisticAsync(request, cancellationToken);
        }

        public async Task<GetRFPStatisticResp> GetRFPStatisticAsync(GetRFPStatistic request, CancellationToken cancellationToken)
        {
            var response = await SendAsync<GetRFPStatistic, GetRFPStatisticResp>(request, cancellationToken).ConfigureAwait(false);
            return response;
        }

        public async Task<GetRFPSummaryResp> GetRFPSummaryAsync(CancellationToken cancellationToken)
        {
            var request = new GetRFPSummary();
            var response = await SendAsync<GetRFPSummary, GetRFPSummaryResp>(request, cancellationToken).ConfigureAwait(false);
            return response;
        }
    }
}