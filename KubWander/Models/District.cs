using System;
using System.Collections.Generic;

namespace KubWander.Models;

public partial class District
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public double? MinLatitude { get; set; }
    public double MinLongitude { get; set; }
    public double? MaxLatitude { get; set; }
    public double MaxLongitude { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
    public virtual ICollection<Place> Places { get; set; } = new List<Place>();

    public virtual ICollection<Quest> Quests { get; set; } = new List<Quest>();
}
