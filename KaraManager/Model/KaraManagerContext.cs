using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace KaraManager.Model
{
    public partial class KaraManagerContext : DbContext
    {
        public KaraManagerContext()
        {
        }

        public KaraManagerContext(DbContextOptions<KaraManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("KaraManager"));  
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Account__F3DBC57381F17726");

                entity.ToTable("Account");

                entity.Property(e => e.Username)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .HasColumnName("role")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Bid)
                    .HasName("PK__Invoice__DE90ADE71CF15040");

                entity.ToTable("Invoice");

                entity.Property(e => e.Bid).HasColumnName("bid");

                entity.Property(e => e.Datecreated)
                    .HasColumnType("date")
                    .HasColumnName("datecreated");

                entity.Property(e => e.Othercost).HasColumnName("othercost");

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.Timeelapsed).HasColumnName("timeelapsed");

                entity.Property(e => e.Timeended)
                    .HasColumnType("datetime")
                    .HasColumnName("timeended");

                entity.Property(e => e.Timestarted)
                    .HasColumnType("datetime")
                    .HasColumnName("timestarted");

                entity.Property(e => e.Totalcost).HasColumnName("totalcost");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Mid);

                entity.ToTable("Message");

                entity.Property(e => e.Mid).HasColumnName("mid");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Receivername)
                    .HasMaxLength(150)
                    .HasColumnName("receivername");

                entity.Property(e => e.Sendername)
                    .HasMaxLength(150)
                    .HasColumnName("sendername");

                entity.Property(e => e.Timesent)
                    .HasColumnType("datetime")
                    .HasColumnName("timesent");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.Rid)
                    .HasName("PK__Room__C2B7EDE820C1E124");

                entity.ToTable("Room");

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.Isused).HasColumnName("isused");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Priceperhour).HasColumnName("priceperhour");

                entity.Property(e => e.Timestarted)
                    .HasColumnType("datetime")
                    .HasColumnName("timestarted");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
