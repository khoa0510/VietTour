﻿namespace VietTour.Models.ViewModels
{
    public class TripComponent
    {
        //trip id
        public int TripId { get; set; }

        // ngày bắt đầu
        public DateOnly DayStart { get; set; }

        // số lượng
        public int Capacity { get; set; }
    }
}