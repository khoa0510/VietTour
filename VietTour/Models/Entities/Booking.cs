using System;
using System.Collections.Generic;

namespace VietTour.Models.Entities;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? UserId { get; set; }

    public int? TourId { get; set; }

    public int? TripId { get; set; }

    public int? Passengers { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? PayDate { get; set; }

    public string? Note { get; set; }

    public virtual Tour? Tour { get; set; }

    public virtual Trip? Trip { get; set; }

    public virtual User? User { get; set; }
}
