using System;
using System.Collections.Generic;

namespace KubWander.Models;

public partial class PhotoReview
{
    public int Id { get; set; }

    public int PhotoId { get; set; }

    public string? ReviewerId { get; set; }

    public DateTime? ReviewedAt { get; set; } = DateTime.UtcNow;

    public string? Comment { get; set; }

    public string Decision { get; set; } = null!;

    public virtual Photo Photo { get; set; } = null!;

    public virtual User? Reviewer { get; set; }
}