using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace KubWander.Models;

public partial class User : IdentityUser
{
    public string Name { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public string Role { get; set; } = "user";
    public int Points { get; set; } = 0;
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<PhotoReview> PhotoReviews { get; set; } = new List<PhotoReview>();
    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
    public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
    public virtual ICollection<UserQuest> UserQuests { get; set; } = new List<UserQuest>();
}