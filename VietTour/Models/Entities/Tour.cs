using System;
using System.Collections.Generic;

namespace VietTour.Entities;

public partial class Tour
{
    public int TourId { get; set; }

    public string? TourName { get; set; }

    public string? Summary { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? ProvinceId { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual Province? Province { get; set; }

    public virtual ICollection<Trip> Trips { get; } = new List<Trip>();
}
