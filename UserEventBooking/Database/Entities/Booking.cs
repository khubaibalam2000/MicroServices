using AdminEventBooking.Database.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserEventBooking.Database.Entities
{
    public class Booking
    {
        public int bookingId { get; set; }
        public string cnic { get; set; } = string.Empty;
        public string ticketNumber { get; set; } = string.Empty;
        public string ticketType { get; set; } = string.Empty;
        public string eventName { get; set; } = string.Empty;
        public DateTime createdDate { get; set; }

    }
}
