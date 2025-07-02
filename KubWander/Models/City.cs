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

    public virtual District District { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();

    public virtual ICollection<Quest> Quests { get; set; } = new List<Quest>();
}
