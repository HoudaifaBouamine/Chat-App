using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models.Dtos.Message
{
    public class MessageIn2UsersChatDto
    {
        public int MessageId { get; set; }
        public string? MessageText { get; set; } = string.Empty;
        public bool SendFromUser1ToUser2 { get; set; } = true;
        public DateTime? SendTime { get; set; }
    }
}
