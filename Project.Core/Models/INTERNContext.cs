using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Project.Core.Models
{
    public partial class INTERNContext : DbContext
    {
        public INTERNContext()
        {
        }

        public INTERNContext(DbContextOptions<INTERNContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DrawedUser> DrawedUsers { get; set; }
        public virtual DbSet<MatchedUser> MatchedUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=172.28.1.84\\ABS_DEV;Database=INTERN;User ID=Intern;Password=Intern2022;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

          

            modelBuilder.Entity<DrawedUser>(entity =>
            {
                entity.HasKey(e => e.ChoserId)
                    .HasName("ChoserId");

                entity.ToTable("DrawedUser");

                entity.Property(e => e.ChoserId).ValueGeneratedNever();

                entity.Property(e => e.ChosenName)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ChosenSurname)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ChoserName)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ChoserSurname)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MatchedUser>(entity =>
            {
                entity.HasKey(e => e.FirstId)
                    .HasName("MatchedUser_pk")
                    .IsClustered(false);

                entity.ToTable("MatchedUser");

                entity.HasIndex(e => e.FirstId, "FirstId")
                    .IsUnique();

                entity.Property(e => e.FirstId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FirstSurname)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

          

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("User_pk")
                    .IsClustered(false);

                entity.ToTable("User");

                entity.HasIndex(e => e.Id, "User_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
