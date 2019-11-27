using System.Threading;
using System.Threading.Tasks;
using mitelapi.Messages;
using mitelapi.Types;

namespace mitelapi
{
    public partial class OmmClient
    {
        /// <summary>
        /// A client can send this request to send a message to a DECT phone.
        /// If the message is accepted by the OMM, it is put into a send queue.
        /// The response to this request is always sent immediately, but it will take a while until the message can be forwarded to a DECT phone.
        /// For that reason the progress of sending the message is reported using Events.
        /// </summary>
        /// <param name="message">Message to be sent.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task SendMessageAsync(MessageType message, CancellationToken cancellationToken)
        {
            var msg = new SendMessage {Msg = message};
            return SendAsync<SendMessage, SendMessageResp>(msg, cancellationToken);
        }
    }
}