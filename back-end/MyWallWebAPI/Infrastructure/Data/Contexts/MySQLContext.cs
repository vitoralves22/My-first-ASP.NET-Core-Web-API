using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWallWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallWebAPI.Infrastructure.Data.Contexts
{
    public class MySQLContext : IdentityDbContext<ApplicationUser>
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {
        }

        public DbSet<Post> Post { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<ChatUser> ChatUser { get; set; }
        public DbSet<MessageReceiver> MessageReceiver { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<ApplicationRole> Role { get; set; }
        public DbSet<ChatInvitation> ChatInvitation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            modelBuilder.Entity<ChatUser>().HasKey(cu => new { cu.ChatId, cu.ApplicationUserId });

            modelBuilder.Entity<MessageReceiver>().HasKey(mr => new { mr.ReceiverId, mr.MessageId });


            modelBuilder.Entity<ChatUser>()
                    .HasOne(u => u.ApplicationUser)
                    .WithMany(cu => cu.ChatUsers)
                    .HasForeignKey(ui => ui.ApplicationUserId);

            modelBuilder.Entity<ChatUser>()
                    .HasOne(c => c.Chat)
                    .WithMany(cu => cu.ChatUsers)
                    .HasForeignKey(c => c.ChatId);   

            modelBuilder.Entity<MessageReceiver>()
                    .HasOne(r => r.Receiver)
                    .WithMany(mr => mr.MessageReceivers)
                    .HasForeignKey(ri => ri.ReceiverId);

            modelBuilder.Entity<MessageReceiver>()
                    .HasOne(r => r.Message)
                    .WithMany(mr => mr.MessageReceivers)
                    .HasForeignKey(ri => ri.MessageId);

            modelBuilder.Entity<Message>()
                    .HasOne(c => c.Chat)
                    .WithMany(m => m.Messages)
                    .HasForeignKey(ci => ci.ChatId);

            modelBuilder.Entity<Message>()
                   .HasOne(s => s.Sender)
                   .WithMany(m => m.Messages)
                   .HasForeignKey(si => si.SenderId);

            modelBuilder.Entity<Chat>()
                   .HasOne(i => i.Initiator)
                   .WithMany(c => c.Chats)
                   .HasForeignKey(ii => ii.InitiatorId);

            modelBuilder.Entity<Like>()
                   .HasOne(p => p.Post)
                   .WithMany(l => l.Likes)
                   .HasForeignKey(pi => pi.PostId);

            modelBuilder.Entity<ChatInvitation>()
                   .HasOne(p => p.Chat)
                   .WithMany(p => p.Invitations)
                   .HasForeignKey(pi => pi.ChatId);

            modelBuilder.Entity<ChatInvitation>()
                  .HasOne(p => p.Sender)
                  .WithMany(p => p.SendedInvitations)
                  .HasForeignKey(pi => pi.SenderId);

            modelBuilder.Entity<ChatInvitation>()
                  .HasOne(p => p.Receiver)
                  .WithMany(p => p.ReceivedInvitations)
                  .HasForeignKey(pi => pi.ReceiverId);

            modelBuilder.Entity<Post>();

        }
    }
}
