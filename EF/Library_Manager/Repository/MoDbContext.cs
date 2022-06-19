using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Library_Manager.Repository.Models;

#nullable disable

namespace Library_Manager.Repository
{
    public partial class MoDbContext : DbContext
    {
        public MoDbContext()
        {
        }

        public MoDbContext(DbContextOptions<MoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthenticationSystem> AuthenticationSystems { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Reader> Readers { get; set; }
        public virtual DbSet<ReverseReturn> ReverseReturns { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Library_Manager;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AuthenticationSystem>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Authenti__536C85E51C4D5E01");

                entity.Property(e => e.Username)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StaffId)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorId)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AuthorId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Price)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PublisherId)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(e => e.PublisherId)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Reader>(entity =>
            {
                entity.Property(e => e.ReaderId)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ReverseReturn>(entity =>
            {
                entity.HasKey(e => e.RegId)
                    .HasName("PK__Reverse___38E88B5753B26104");

                entity.Property(e => e.RegId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BookId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReaderId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReserveStaffId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReturnStaffId)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.Property(e => e.StaffId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Salary)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
