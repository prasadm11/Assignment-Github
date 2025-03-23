﻿using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleRentalSys.Models;


namespace VehicleRentalSys.Services.Interface
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int bookingId);
        Task AddBookingAsync(Booking booking);
        Task UpdateBookingAsync(Booking booking);
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId);
        Task<IEnumerable<Booking>> GetBookingsByVehicleIdAsync(int vehicleId);
        Task DeleteBookingAsync(int bookingId);
    }
}
