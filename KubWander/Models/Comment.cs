using System;
using System.Collections.Generic;

namespace KubWander.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? QuestId { get; set; }

    public int? PhotoId { get; set; }

    public string Text { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Photo? Photo { get; set; }

    public virtual Quest? Quest { get; set; }

    public virtual User User { get; set; } = null!;
}
