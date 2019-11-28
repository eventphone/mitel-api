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

        /// <summary>
        /// A client can send this request to delete a message from a DECT phone.
        /// If the message which has to be deleted is still buffered in the OMM, it is removed from the queue, in this case this request has the same semantic as <see cref="CancelMessageAsync"/>.
        /// If the request is accepted by the OMM, it is put into the same queue as a message which had to be sent would have been put.
        /// The response to this request is always sent immediately, but it will take a while until the delete request can be actually forwarded to a DECT phone.
        /// For that reason the progress of deleting a message is reported using Events
        /// </summary>
        /// <param name="id">Message ID.</param>
        /// <param name="sendTime">Original send time of the message to be deleted.</param>
        /// <param name="toAddr">Recipient address of the message to be deleted. Must have the same scheme as the original message (e.g. "tel:" or "ppn:").</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task DeleteMessageAsync(uint id, uint sendTime, string toAddr, CancellationToken cancellationToken)
        {
            var delete = new DeleteMessage
            {
                Id = id,
                SendTime = sendTime,
                ToAddr = toAddr
            };
            return SendAsync<DeleteMessage, DeleteMessageResp>(delete, cancellationToken);
        }

        /// <summary>
        /// A client can send this request to remove a message from the send queue.
        /// If the message which has to be cancelled is still buffered in the OMM, it is removed from the queue.
        /// If it has been delivered already, this request has no effect.
        /// </summary>
        /// <param name="id">Message ID.</param>
        /// <param name="sendTime">Original send time of the message to be cancelled.</param>
        /// <param name="toAddr">Recipient address of the message to be cancelled. Must have the same scheme as the original message ( e. g. "tel:" or "ppn:").</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task CancelMessageAsync(uint id, uint sendTime, string toAddr, CancellationToken cancellationToken)
        {
            var cancel = new CancelMessage
            {
                Id = id,
                SendTime = sendTime,
                ToAddr = toAddr
            };
            return SendAsync<CancelMessage, CancelMessageResp>(cancel, cancellationToken);
        }
    }
}