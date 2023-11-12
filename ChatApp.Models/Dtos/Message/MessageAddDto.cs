using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models.Dtos.Message
{
    public class MessageAddDto
    {
        public string? MessageText { get; set; } = string.Empty;
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
    }

}
