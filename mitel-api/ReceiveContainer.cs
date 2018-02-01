using System;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using mitelapi.Messages;

namespace mitelapi
{
    internal class ReceiveContainer:IDisposable
    {
        private readonly SemaphoreSlim _resetEvent;
        private BaseResponse _response;

        public ReceiveContainer(int seq)
        {
            Seq = seq;
            _resetEvent = new SemaphoreSlim(0, 1);
        }

        public int Seq { get; private set; }

        public BaseResponse Response
        {
            get
            {
                return _response;
            }
            set
            {
                _response = value;
                _resetEvent.Release();
            }
        }

        public async Task<BaseResponse> GetResponseAsync(CancellationToken cancellationToken)
        {
            await _resetEvent.WaitAsync(cancellationToken).ConfigureAwait(false);
            var result = Response;
            if (result.ErrorCode != OmmError.None)
            {
                throw new OmmException(result.ErrorCode, result.Info, result.ErrorBad, result.ErrorMaxLength);
            }
            return result;
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _resetEvent?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}