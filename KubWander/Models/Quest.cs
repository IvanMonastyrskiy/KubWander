using System;
using System.Collections.Generic;

namespace KubWander.Models;

public partial class Quest
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Type { get; set; } = null!;

    public int? CityId { get; set; }

    public int? DistrictId { get; set; }

    public int? PlaceId { get; set; }

    public int? RewardPoints { get; set; }

    public string? ExamplePhotoUrl { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual District? District { get; set; }

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual Place? Place { get; set; }

    public virtual ICollection<UserQuest> UserQuests { get; set; } = new List<UserQuest>();
}
