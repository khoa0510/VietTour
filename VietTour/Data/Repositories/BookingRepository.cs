using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VietTour.Areas.Admin.Models;
using VietTour.Areas.Shared.Models;
using VietTour.Data.Entities;

namespace VietTour.Data.Repositories
{
    public class BookingRepository
    {
        private readonly ViettourContext _context;
        private readonly IMapper _mapper;

        public BookingRepository(ViettourContext viettourContext, IMapper mapper)
        {
            _context = viettourContext;
            _mapper = mapper;
        }

        public List<BookingComponent> GetAll(int pageNumber, int pageSize, string? sortBy, string? search)
        {
            var bookings = _context.Bookings.AsNoTracking();
            if (!string.IsNullOrEmpty(search))
            {
                var userId = _context.Users.SingleOrDefault(u => u.Username == search)?.UserId;
                bookings = bookings.Where(b => b.UserId == userId);
            }
            List<Booking> bookingList;
            bookingList = bookings.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            List<BookingComponent> bookingComponents = new();
            foreach (var booking in bookingList)
            {
                BookingComponent bookingComponent = new();
                bookingComponent.BookingId = booking.BookingId;
                bookingComponent.TourName = _context.Tours.SingleOrDefault(t => t.TourId == booking.TourId)?.TourName;
                bookingComponent.Username = _context.Users.SingleOrDefault(u => u.UserId == booking.UserId)?.Username;
                bookingComponent.Passengers = booking.Passengers;
                bookingComponent.IsPaid = (booking.PayDate!= null)? true: false;
                bookingComponents.Add(bookingComponent);
            }
            return bookingComponents;
        }

        public EditBookingViewModel? GetBooking(int id)
        {
            var booking = _context.Bookings.SingleOrDefault(b => b.BookingId == id);
            EditBookingViewModel editBookingViewModel = new();
            editBookingViewModel.TourId = booking.TourId;
            editBookingViewModel.TourName = _context.Tours.SingleOrDefault(t => t.TourId == booking.TourId)?.TourName;
            editBookingViewModel.DayStart = _context.Trips.SingleOrDefault(t => t.TripId == booking.TripId).DayStart;
            editBookingViewModel.Passengers = booking.Passengers;
            editBookingViewModel.CreateDate = booking.CreateDate;
            editBookingViewModel.IsPaid = (booking.PayDate == null) ? "Chưa thanh toán" : "Đã thanh toán";
            editBookingViewModel.Note= booking.Note;
            return editBookingViewModel;
        }

        public bool EditBooking(int id, EditBookingViewModel editBookingViewModel)
        {
            var booking = _context.Bookings.SingleOrDefault(b => b.BookingId == id);
            booking.TripId = _context.Trips.SingleOrDefault(t => t.DayStart == editBookingViewModel.DayStart).TripId;
            booking.Passengers = editBookingViewModel.Passengers;
            if (booking.PayDate == null && editBookingViewModel.IsPaid == "Đã thanh toán") booking.PayDate = DateTime.Now;
            booking.Note= editBookingViewModel.Note;

            _context.SaveChanges();
            return true;
        }

        public void DeleteBooking(int id)
        {
            var booking = _context.Bookings.SingleOrDefault(b => b.BookingId == id);

            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }
    }
}
