using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public enum BookingStatus { Pending, Confirmed, Canceled}
    public class Booking
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public Guid TenantId { get; set; }
        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; }
    }
}
