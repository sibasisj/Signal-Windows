using Signal_Windows.Controls;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Signal_Windows.Models
{
    public class SignalMessage
    {
        public ulong Id { get; set; }
        public uint Type { get; set; }
        public uint Status { get; set; }
        public string Content { get; set; }
        public string ThreadID { get; set; }
        public ulong? AuthorId { get; set; }
        public SignalContact Author { get; set; }
        public uint DeviceId { get; set; }
        public uint Receipts { get; set; }
        public uint ReadConfirmations { get; set; }
        public long ReceivedTimestamp { get; set; }
        public long ComposedTimestamp { get; set; }
        public uint AttachmentsCount { get; set; }
        public List<SignalAttachment> Attachments { get; set; }
        [NotMapped] public MessageBox View { get; set; }
    }

    public enum SignalMessageType
    {
        Outgoing = 0,
        Incoming = 1,
        Synced = 2
    }

    public enum SignalMessageStatus
    {
        Pending = 0,
        Confirmed = 1,
        Received = 2
    }
}
