using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cricket.Models
{
    public partial class CricketContext : DbContext
    {
        public CricketContext()
        {
        }

        public CricketContext(DbContextOptions<CricketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Stadium> Stadium { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Cricket;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).HasColumnName("Country_Id");

                entity.Property(e => e.Continent).HasMaxLength(30);

                entity.Property(e => e.CountryCode)
                    .HasColumnName("Country_Code")
                    .HasMaxLength(20);

                entity.Property(e => e.CountryName)
                    .HasColumnName("Country_Name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Matches>(entity =>
            {
                entity.HasKey(e => e.MatchId);

                entity.Property(e => e.MatchId).HasColumnName("Match_id");

                entity.Property(e => e.DateTime)
                    .HasColumnName("Date_Time")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Result)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StadiumName)
                    .HasColumnName("Stadium_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TeamA).HasColumnName("Team_A");

                entity.Property(e => e.TeamB).HasColumnName("Team_B");

                entity.Property(e => e.WasMatchPlayed)
                    .HasColumnName("Was_Match_Played")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.TeamANavigation)
                    .WithMany(p => p.MatchesTeamANavigation)
                    .HasForeignKey(d => d.TeamA)
                    .HasConstraintName("FK__Matches__Team_A__6A30C649");

                entity.HasOne(d => d.TeamBNavigation)
                    .WithMany(p => p.MatchesTeamBNavigation)
                    .HasForeignKey(d => d.TeamB)
                    .HasConstraintName("FK__Matches__Team_B__6B24EA82");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerId).HasColumnName("Player_Id");

                entity.Property(e => e.CountryId).HasColumnName("Country_id");

                entity.Property(e => e.PlayerAge).HasColumnName("player_Age");

                entity.Property(e => e.PlayerName)
                    .HasColumnName("Player_Name")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Player__Country___619B8048");
            });

            modelBuilder.Entity<Stadium>(entity =>
            {
                entity.HasKey(e => e.StadiumName);

                entity.Property(e => e.StadiumName)
                    .HasColumnName("Stadium_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MatchesAllowed).HasColumnName("Matches_allowed");

                entity.Property(e => e.StadiumCapacity).HasColumnName("Stadium_capacity");

                entity.Property(e => e.StadiumId).HasColumnName("Stadium_id");

                entity.HasOne(d => d.StadiumNavigation)
                    .WithMany(p => p.Stadium)
                    .HasForeignKey(d => d.StadiumId)
                    .HasConstraintName("FK__Stadium__Stadium__70DDC3D8");
            });
        }
    }
}
