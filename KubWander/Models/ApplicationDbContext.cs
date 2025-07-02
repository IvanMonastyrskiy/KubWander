using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KubWander.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<PhotoReview> PhotoReviews { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<Quest> Quests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAchievement> UserAchievements { get; set; }

    public virtual DbSet<UserQuest> UserQuests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=KubWanderData;Username=postgres;Password=20Ivan062005");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("achievements_pkey");

            entity.ToTable("achievements");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IconUrl).HasColumnName("icon_url");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cities_pkey");

            entity.ToTable("cities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.District).WithMany(p => p.Cities)
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("cities_district_id_fkey");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comments_pkey");

            entity.ToTable("comments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.PhotoId).HasColumnName("photo_id");
            entity.Property(e => e.QuestId).HasColumnName("quest_id");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Photo).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PhotoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comments_photo_id_fkey");

            entity.HasOne(d => d.Quest).WithMany(p => p.Comments)
                .HasForeignKey(d => d.QuestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comments_quest_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("comments_user_id_fkey");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("districts_pkey");

            entity.ToTable("districts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("photos_pkey");

            entity.ToTable("photos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
            entity.Property(e => e.QuestId).HasColumnName("quest_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValueSql("'pending'::character varying")
                .HasColumnName("status");
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("uploaded_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Quest).WithMany(p => p.Photos)
                .HasForeignKey(d => d.QuestId)
                .HasConstraintName("photos_quest_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Photos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("photos_user_id_fkey");
        });

        modelBuilder.Entity<PhotoReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("photo_reviews_pkey");

            entity.ToTable("photo_reviews");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Decision)
                .HasMaxLength(20)
                .HasColumnName("decision");
            entity.Property(e => e.PhotoId).HasColumnName("photo_id");
            entity.Property(e => e.ReviewedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("reviewed_at");
            entity.Property(e => e.ReviewerId).HasColumnName("reviewer_id");

            entity.HasOne(d => d.Photo).WithMany(p => p.PhotoReviews)
                .HasForeignKey(d => d.PhotoId)
                .HasConstraintName("photo_reviews_photo_id_fkey");

            entity.HasOne(d => d.Reviewer).WithMany(p => p.PhotoReviews)
                .HasForeignKey(d => d.ReviewerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("photo_reviews_reviewer_id_fkey");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("places_pkey");

            entity.ToTable("places");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");

            entity.HasOne(d => d.City).WithMany(p => p.Places)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("places_city_id_fkey");
        });

        modelBuilder.Entity<Quest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("quests_pkey");

            entity.ToTable("quests");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.ExamplePhotoUrl).HasColumnName("example_photo_url");
            entity.Property(e => e.PlaceId).HasColumnName("place_id");
            entity.Property(e => e.RewardPoints)
                .HasDefaultValue(10)
                .HasColumnName("reward_points");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");

            entity.HasOne(d => d.City).WithMany(p => p.Quests)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("quests_city_id_fkey");

            entity.HasOne(d => d.District).WithMany(p => p.Quests)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("quests_district_id_fkey");

            entity.HasOne(d => d.Place).WithMany(p => p.Quests)
                .HasForeignKey(d => d.PlaceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("quests_place_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvatarUrl).HasColumnName("avatar_url");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.Points)
                .HasDefaultValue(0)
                .HasColumnName("points");
            entity.Property(e => e.RegisteredAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("registered_at");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValueSql("'user'::character varying")
                .HasColumnName("role");
        });

        modelBuilder.Entity<UserAchievement>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.AchievementId }).HasName("user_achievements_pkey");

            entity.ToTable("user_achievements");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.AchievementId).HasColumnName("achievement_id");
            entity.Property(e => e.ReceivedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("received_at");

            entity.HasOne(d => d.Achievement).WithMany(p => p.UserAchievements)
                .HasForeignKey(d => d.AchievementId)
                .HasConstraintName("user_achievements_achievement_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UserAchievements)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_achievements_user_id_fkey");
        });

        modelBuilder.Entity<UserQuest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_quests_pkey");

            entity.ToTable("user_quests");

            entity.HasIndex(e => new { e.UserId, e.QuestId }, "unique_user_quest").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompletedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("completed_at");
            entity.Property(e => e.PhotoId).HasColumnName("photo_id");
            entity.Property(e => e.QuestId).HasColumnName("quest_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValueSql("'pending'::character varying")
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Photo).WithMany(p => p.UserQuests)
                .HasForeignKey(d => d.PhotoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("user_quests_photo_id_fkey");

            entity.HasOne(d => d.Quest).WithMany(p => p.UserQuests)
                .HasForeignKey(d => d.QuestId)
                .HasConstraintName("user_quests_quest_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UserQuests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_quests_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
