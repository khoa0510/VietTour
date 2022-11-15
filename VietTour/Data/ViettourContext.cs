using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VietTour.Entities;

namespace VietTour.Data;

public partial class ViettourContext : DbContext
{
	public ViettourContext(DbContextOptions<ViettourContext> options) : base(options)
	{
	}

	public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__BOOKINGS__C1EBE7B336E98CCD");

            entity.ToTable("BOOKINGS");

            entity.Property(e => e.BookingId).HasColumnName("BOOKING_ID");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATE_DATE");
            entity.Property(e => e.Note)
                .HasMaxLength(1)
                .HasColumnName("NOTE");
            entity.Property(e => e.Passengers).HasColumnName("PASSENGERS");
            entity.Property(e => e.PayDate)
                .HasColumnType("datetime")
                .HasColumnName("PAY_DATE");
            entity.Property(e => e.TourId).HasColumnName("TOUR_ID");
            entity.Property(e => e.TripId).HasColumnName("TRIP_ID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.Tour).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TourId)
                .HasConstraintName("FK__BOOKINGS__TOUR_I__32E0915F");

            entity.HasOne(d => d.Trip).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("FK__BOOKINGS__TRIP_I__33D4B598");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__BOOKINGS__USER_I__31EC6D26");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__COMMENTS__C55F98D01149B85F");

            entity.ToTable("COMMENTS");

            entity.Property(e => e.CommentId).HasColumnName("COMMENT_ID");
            entity.Property(e => e.Content)
                .HasMaxLength(1)
                .HasColumnName("CONTENT");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("DATE");
            entity.Property(e => e.TourId).HasColumnName("TOUR_ID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.Tour).WithMany(p => p.Comments)
                .HasForeignKey(d => d.TourId)
                .HasConstraintName("FK__COMMENTS__TOUR_I__2C3393D0");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__COMMENTS__USER_I__2B3F6F97");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.ProvinceId).HasName("PK__PROVINCE__33EF610E552AA52E");

            entity.ToTable("PROVINCES");

            entity.Property(e => e.ProvinceId).HasColumnName("PROVINCE_ID");
            entity.Property(e => e.ProvinceName)
                .HasMaxLength(1)
                .HasColumnName("PROVINCE_NAME");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.TourId).HasName("PK__TOURS__B8ED713BBEBC645A");

            entity.ToTable("TOURS");

            entity.Property(e => e.TourId).HasColumnName("TOUR_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(1)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRICE");
            entity.Property(e => e.ProvinceId).HasColumnName("PROVINCE_ID");
            entity.Property(e => e.Summary)
                .HasMaxLength(1)
                .HasColumnName("SUMMARY");
            entity.Property(e => e.TourName)
                .HasMaxLength(1)
                .HasColumnName("TOUR_NAME");

            entity.HasOne(d => d.Province).WithMany(p => p.Tours)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("FK__TOURS__PROVINCE___286302EC");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("PK__TRIPS__92362727FFDD1B3B");

            entity.ToTable("TRIPS");

            entity.Property(e => e.TripId).HasColumnName("TRIP_ID");
            entity.Property(e => e.Capacity).HasColumnName("CAPACITY");
            entity.Property(e => e.DayStart)
                .HasColumnType("date")
                .HasColumnName("DAY_START");
            entity.Property(e => e.TourId).HasColumnName("TOUR_ID");

            entity.HasOne(d => d.Tour).WithMany(p => p.Trips)
                .HasForeignKey(d => d.TourId)
                .HasConstraintName("FK__TRIPS__TOUR_ID__2F10007B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__USERS__F3BEEBFF96BBFCE4");

            entity.ToTable("USERS");

            entity.Property(e => e.UserId).HasColumnName("USER_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(1)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Admin).HasColumnName("ADMIN");
            entity.Property(e => e.Email)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Password)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PHONE");
            entity.Property(e => e.Username)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
