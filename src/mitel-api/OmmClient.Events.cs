using System;
using mitelapi.Events;
using mitelapi.Messages;

namespace mitelapi
{
    public partial class OmmClient
    {
        public event EventHandler<LogMessageEventArgs> MessageLog;
        private event EventHandler<MessageReceivedEventArgs> MessageReceived;
        
        public event EventHandler<OmmEventArgs<EventAlarmCallProgress>> AlarmCallProgress;
        public event EventHandler<OmmEventArgs<EventDECTSubscriptionMode>> DECTSubscriptionModeChanged;
        public event EventHandler<OmmEventArgs<EventPPCnf>> PPCnf;
        public event EventHandler<OmmEventArgs<EventPPDevCnf>> PPDevCnf;
        public event EventHandler<OmmEventArgs<EventPPDevSummary>> PPDevSummary;
        public event EventHandler<OmmEventArgs<EventPPUserCnf>> PPUserCnf;
        public event EventHandler<OmmEventArgs<EventPPUserSummary>> PPUserSummary;
        public event EventHandler<OmmEventArgs<EventRFPState>> RFPState;
        public event EventHandler<OmmEventArgs<EventRFPCnf>> RFPCnf;
        public event EventHandler<OmmEventArgs<EventRFPSummary>> RfpSummary;
        public event EventHandler<OmmEventArgs<EventRFPSyncQuality>> RFPSyncQuality;
        public event EventHandler<OmmEventArgs<EventRFPSyncRel>> RFPSyncRel;
        public event EventHandler<OmmEventArgs<EventStbStateChange>> StbStateChange;
        public event EventHandler<OmmEventArgs<EventLicenseCnf>> LicenseCnf;
        public event EventHandler<OmmEventArgs<EventMessageProgress>> MessageProgress;
        public event EventHandler<OmmEventArgs<EventMessageConfirmation>> MessageConfirmation;
        public event EventHandler<OmmEventArgs<EventMessageQueueEmpty>> MessageQueueEmpty;
        public event EventHandler<OmmEventArgs<EventMessageSend>> MessageSend;

        private void OnMessageReceived(BaseResponse message)
        {
            if (message == null) return;
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(message));
        }

        private void OnMessageLog(string message, MessageDirection direction)
        {
            if (String.IsNullOrEmpty(message)) return;
            MessageLog?.Invoke(this, new LogMessageEventArgs(message, direction));
        }

        private void OnEventReceived(BaseEvent ommEvent)
        {
            if (ommEvent == null) return;
            if (ommEvent is EventDECTSubscriptionMode dectSubscriptionMode)
            {
                DECTSubscriptionModeChanged?.Invoke(this, new OmmEventArgs<EventDECTSubscriptionMode>(dectSubscriptionMode));
            }
            else if (ommEvent is EventAlarmCallProgress alarmCallProgress)
            {
                AlarmCallProgress?.Invoke(this, new OmmEventArgs<EventAlarmCallProgress>(alarmCallProgress));
            }
            else if (ommEvent is EventRFPSummary rfpSummary)
            {
                RfpSummary?.Invoke(this, new OmmEventArgs<EventRFPSummary>(rfpSummary));
            }
            else if (ommEvent is EventPPDevSummary ppDevSummary)
            {
                PPDevSummary?.Invoke(this, new OmmEventArgs<EventPPDevSummary>(ppDevSummary));
            }
            else if (ommEvent is EventPPUserSummary ppUserSummary)
            {
                PPUserSummary?.Invoke(this, new OmmEventArgs<EventPPUserSummary>(ppUserSummary));
            }
            else if (ommEvent is EventPPDevCnf ppDevCnf)
            {
                PPDevCnf?.Invoke(this, new OmmEventArgs<EventPPDevCnf>(ppDevCnf));
            }
            else if (ommEvent is EventPPUserCnf ppUserCnf)
            {
                PPUserCnf?.Invoke(this, new OmmEventArgs<EventPPUserCnf>(ppUserCnf));
            }
            else if (ommEvent is EventPPCnf ppCnf)
            {
                PPCnf?.Invoke(this, new OmmEventArgs<EventPPCnf>(ppCnf));
            }
            else if (ommEvent is EventRFPState rfpState)
            {
                RFPState?.Invoke(this, new OmmEventArgs<EventRFPState>(rfpState));
            }
            else if (ommEvent is EventRFPCnf rfpCnf)
            {
                RFPCnf?.Invoke(this, new OmmEventArgs<EventRFPCnf>(rfpCnf));
            }
            else if (ommEvent is EventRFPSyncRel rfpSyncRel)
            {
                RFPSyncRel?.Invoke(this, new OmmEventArgs<EventRFPSyncRel>(rfpSyncRel));
            }
            else if (ommEvent is EventRFPSyncQuality rfpSyncQuality)
            {
                RFPSyncQuality?.Invoke(this, new OmmEventArgs<EventRFPSyncQuality>(rfpSyncQuality));
            }
            else if (ommEvent is EventStbStateChange stbStateChange)
            {
                StbStateChange?.Invoke(this, new OmmEventArgs<EventStbStateChange>(stbStateChange));
            }
            else if (ommEvent is EventLicenseCnf licenseCnf)
            {
                LicenseCnf?.Invoke(this, new OmmEventArgs<EventLicenseCnf>(licenseCnf));
            }
            else if (ommEvent is EventMessageProgress messageProgress)
            {
                MessageProgress?.Invoke(this, new OmmEventArgs<EventMessageProgress>(messageProgress));
            }
            else if (ommEvent is EventMessageConfirmation messageConfirmation)
            {
                MessageConfirmation?.Invoke(this, new OmmEventArgs<EventMessageConfirmation>(messageConfirmation));
            }
            else if (ommEvent is EventMessageQueueEmpty messageQueueEmpty)
            {
                MessageQueueEmpty?.Invoke(this, new OmmEventArgs<EventMessageQueueEmpty>(messageQueueEmpty));
            }
            else if (ommEvent is EventMessageSend messageSend)
            {
                MessageSend?.Invoke(this, new OmmEventArgs<EventMessageSend>(messageSend));
            }
        }
    }
}