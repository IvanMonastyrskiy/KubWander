using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KubWander.Models;

public partial class Place
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public string? Address { get; set; }

    public string? Description { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public int? CityId { get; set; }

    public virtual City? City { get; set; }
    public int? DistrictId { get; set; }
    [Column("districtId")]
    public virtual District? District { get; set; }

    public virtual ICollection<Quest> Quests { get; set; } = new List<Quest>();
}
