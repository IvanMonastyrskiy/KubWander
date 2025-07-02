using System;
using System.Collections.Generic;

namespace KubWander.Models;

public partial class UserQuest
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int QuestId { get; set; }

    public int? PhotoId { get; set; }

    public DateTime? CompletedAt { get; set; }

    public string? Status { get; set; }

    public virtual Photo? Photo { get; set; }

    public virtual Quest Quest { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
