using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models.Dtos.Message
{
    public class MessageReadDto
    {
        public int MessageId { get; set; }

        public string? MessageText { get; set; } = string.Empty;

        public int? SenderId { get; set; }
        public string? SenderUserName { get; set; } = string.Empty;

        public int? ReceiverId { get; set; }
        public string? ReceiverUserName { get; set; } = string.Empty;

        public DateTime? SendTime { get; set; }

    }

}
