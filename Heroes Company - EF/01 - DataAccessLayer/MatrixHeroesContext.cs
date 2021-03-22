using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Matrix
{
    public partial class MatrixHeroesContext : DbContext
    {
        public MatrixHeroesContext()
        {
        }

        public MatrixHeroesContext(DbContextOptions<MatrixHeroesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hero> Heroes { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-C2FEDD5\\SQLEXPRESS;Database=MatrixHeroes;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Hero>(entity =>
            {
                entity.Property(e => e.HeroId).HasMaxLength(100);

                entity.Property(e => e.Ability)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrentPower).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartingPower).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SuitColors)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TrainStartDate).HasColumnType("datetime");

                entity.Property(e => e.TrainerId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.Heroes)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Heroes_Trainers");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.Property(e => e.TrainerId).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
