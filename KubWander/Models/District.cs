using System;
using System.Collections.Generic;

namespace KubWander.Models;

public partial class District
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual ICollection<Quest> Quests { get; set; } = new List<Quest>();
}
