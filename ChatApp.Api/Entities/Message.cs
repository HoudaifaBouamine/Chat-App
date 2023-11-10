using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Api.Entities;

public partial class Message
{
    [Key]
    public int MessageId { get; set; }

    public string? MessageText { get; set; }

    public int? SenderId { get; set; }

    public int? ReceiverId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SendTime { get; set; }

    [ForeignKey("ReceiverId")]
    [InverseProperty("MessageReceivers")]
    public virtual User? Receiver { get; set; }

    [ForeignKey("SenderId")]
    [InverseProperty("MessageSenders")]
    public virtual User? Sender { get; set; }
}
