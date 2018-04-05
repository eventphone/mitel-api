using System;
using mitelapi.Events;

namespace mitelapi
{
    public class OmmEventArgs<T> : EventArgs where T : BaseEvent
    {
        public OmmEventArgs(T ommEvent)
        {
            Event = ommEvent;
        }

        public T Event { get; private set; }
    }
}