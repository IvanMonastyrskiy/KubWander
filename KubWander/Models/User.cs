using System;
using System.Collections.Generic;

namespace KubWander.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public string? Role { get; set; }

    public int? Points { get; set; }

    public DateTime? RegisteredAt { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<PhotoReview> PhotoReviews { get; set; } = new List<PhotoReview>();

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();

    public virtual ICollection<UserQuest> UserQuests { get; set; } = new List<UserQuest>();
}
