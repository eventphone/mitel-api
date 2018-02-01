using System;
using mitelapi.Messages;

namespace mitelapi
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public MessageReceivedEventArgs(BaseResponse message)
        {
            Message = message;
        }

        public BaseResponse Message { get; private set; }

        public bool IsHandled { get; set; }
    }
}