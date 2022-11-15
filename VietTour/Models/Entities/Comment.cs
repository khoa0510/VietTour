using System;
using System.Collections.Generic;

namespace VietTour.Entities;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? UserId { get; set; }

    public int? TourId { get; set; }

    public string? Content { get; set; }

    public DateTime? Date { get; set; }

    public virtual Tour? Tour { get; set; }

    public virtual User? User { get; set; }
}
