using mitelapi.Messages;
using mitelapi.Types;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace mitelapi
{
    public partial class OmmClient
    {
        public Task<GetAlarmTriggerSummaryResp> GetAlarmTriggerSummaryAsync(CancellationToken cancellationToken)
        {
            return SendAsync<GetAlarmTriggerSummary, GetAlarmTriggerSummaryResp>(new GetAlarmTriggerSummary(), cancellationToken);
        }

        public Task<GetAlarmTriggerResp> GetAlarmTriggerAsync(int id, int maxRecords, CancellationToken cancellationToken)
        {
            var request = new GetAlarmTrigger{ Id = id, MaxRecords = maxRecords };
            return SendAsync<GetAlarmTrigger, GetAlarmTriggerResp>(request, cancellationToken);
        }

        public Task<SetAlarmTriggerResp> SetAlarmTriggerAsync(AlarmTriggerType alarm, CancellationToken cancellationToken)
        {
            return SendAsync<SetAlarmTrigger, SetAlarmTriggerResp>(new SetAlarmTrigger{ Trigger = alarm}, cancellationToken);
        }
    }
}
