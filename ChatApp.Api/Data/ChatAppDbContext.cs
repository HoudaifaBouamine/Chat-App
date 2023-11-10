using System;
using System.Collections.Generic;
using ChatApp.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Api.Data;

public partial class ChatAppDbContext : DbContext
{
    public ChatAppDbContext()
    {
    }

    public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source = .; Initial Catalog = ChatAppDB; User Id = sa; Password=sa123456; Trusted_Connection=true;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Messages__C87C0C9CF72B454A");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MessageReceivers).HasConstraintName("FK__Messages__Receiv__3C69FB99");

            entity.HasOne(d => d.Sender).WithMany(p => p.MessageSenders).HasConstraintName("FK__Messages__Sender__3B75D760");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C53490D90");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
