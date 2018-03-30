using System;

namespace mitelapi
{
    public class LogMessageEventArgs : EventArgs
    {
        public LogMessageEventArgs(string message, MessageDirection direction)
        {
            Message = message;
            Direction = direction;
        }

        public string Message { get; }

        public MessageDirection Direction { get; }
    }

    public enum MessageDirection
    {
        In,
        Out
    }
}