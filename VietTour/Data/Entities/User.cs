using System;
using System.Collections.Generic;

namespace VietTour.Data.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Username { get; set; }

    public string? Address { get; set; }

    public string? Password { get; set; }

    public bool? Admin { get; set; }

    public string? CookieId { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();
}
