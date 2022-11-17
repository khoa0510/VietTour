using System;
using System.Collections.Generic;

namespace VietTour.Models.Entities;

public partial class Province
{
    public int ProvinceId { get; set; }

    public string? ProvinceName { get; set; }

    public virtual ICollection<Tour> Tours { get; } = new List<Tour>();
}
