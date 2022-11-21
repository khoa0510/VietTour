using System;
using System.Collections.Generic;

namespace VietTour.Models.Entities;

public partial class Trip
{
    public int TripId { get; set; }

    public int? TourId { get; set; }

    public DateTime? DayStart { get; set; }

    public int? Capacity { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual Tour? Tour { get; set; }
}
