using System;
using System.Collections.Generic;

namespace KubWander.Models;

public partial class UserAchievement
{
    public string UserId { get; set; } = null!; 

    public int AchievementId { get; set; }

    public DateTime? ReceivedAt { get; set; } = DateTime.UtcNow;

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}