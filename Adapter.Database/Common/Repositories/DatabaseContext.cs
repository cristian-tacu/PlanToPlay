using DomainApi.Players.Models;
using Microsoft.EntityFrameworkCore;

namespace Adapter.Database.Common.Repositories;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PlayerModel> Players { get; init; } = null!;

    public virtual DbSet<RoomModel> Rooms { get; init; } = null!;

    public virtual DbSet<PlayerRoomModel> PlayerRooms { get; init; } = null!;

    public virtual DbSet<StatsModel> Stats { get; init; } = null!;
    public virtual DbSet<GradeModel> Grades { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerModel>(entity =>
        {
            entity.HasKey("Id").HasName("PRIMARY");

            entity.Property<string>(e => e.FirstName)
                .HasMaxLength(30)
                .HasColumnName("first_name");

            entity.Property<string>(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property<string>(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property<string>(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Grade)
                .HasColumnName("grade");
        });
        
        modelBuilder.Entity<RoomModel>(entity =>
        {
            entity.HasKey("Id").HasName("PRIMARY");

            entity.Property<string>(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");

            entity.Property<string>(e => e.Description)
                .HasMaxLength(30)
                .HasColumnName("description");
        });
        
        modelBuilder.Entity<StatsModel>(entity =>
        {
            entity.HasKey("Id").HasName("PRIMARY");

            entity.Property(e => e.LastWeek)
                .HasColumnName("last_week");

            entity.Property(e => e.Last2Weeks)
                .HasColumnName("last_week2");
            entity.Property(e => e.Last3Weeks)
                .HasColumnName("last_week3");
            
            entity.HasIndex(e => e.PlayerRoomId, "Stats_PlayerRoom_id_fk_idx");
            
            entity.HasOne(e => e.PlayerRoom)
                .WithOne(p => p.Stats)
                .HasForeignKey<StatsModel>(s => s.PlayerRoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Stats_PlayerRoom_id_fk");
        });
        
        modelBuilder.Entity<PlayerRoomModel>(entity =>
        {
            entity.HasKey("Id").HasName("PRIMARY");

            entity.Property<string>(e => e.PlayerId)
                .HasMaxLength(30)
                .HasColumnName("player_id");

            entity.Property<string>(e => e.RoomId)
                .HasMaxLength(30)
                .HasColumnName("room_id");
            
            entity.HasIndex(e => e.PlayerId, "PlayerRoom_Players_id_idx");
            
            entity.HasOne(e => e.Player)
                .WithMany(p => p.PlayerRooms)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PlayerRoom_Players_id_fk");
            
            entity.HasIndex(e => e.RoomId, "PlayerRoom_Rooms_id_idx");

            entity.HasOne(e => e.Room)
                .WithMany(p => p.PlayerRooms)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("PlayerRoom_Rooms_id_fk");
        });
        
        modelBuilder.Entity<GradeModel>(entity =>
        {
            entity.HasKey("Id").HasName("PRIMARY");

            entity.Property<string>(e => e.PlayerRoomId)
                .HasMaxLength(30)
                .HasColumnName("player_room_id");

            entity.Property<string>(e => e.EvaluatorPlayerId)
                .HasMaxLength(30)
                .HasColumnName("grader_player_id");

            entity.Property<double>(e => e.Grade)
                .HasColumnName("grade");
            
            entity.HasIndex(e => e.PlayerRoomId, "Grade_PlayerRoom_id_idx");

            entity.HasOne(e => e.PlayerRoom)
                .WithMany(p => p.Grades)
                .HasForeignKey(d => d.PlayerRoomId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Grade_PlayerRoom_id_fk");
        });
            
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}