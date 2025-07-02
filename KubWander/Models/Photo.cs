using System;
using System.Collections.Generic;

namespace KubWander.Models;

public partial class Photo
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int QuestId { get; set; }

    public DateTime? UploadedAt { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? Description { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<PhotoReview> PhotoReviews { get; set; } = new List<PhotoReview>();

    public virtual Quest Quest { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserQuest> UserQuests { get; set; } = new List<UserQuest>();
}
