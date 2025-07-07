using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KubWander.Models;
[Table("cities")]
public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DistrictId { get; set; }
    [Column("description")]
    public string? Description { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public double? MinLatitude { get; set; }
    public double MinLongitude { get; set; }
    public double? MaxLatitude { get; set; }
    public double MaxLongitude { get; set; }

    public virtual District District { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();

    public virtual ICollection<Quest> Quests { get; set; } = new List<Quest>();
}
