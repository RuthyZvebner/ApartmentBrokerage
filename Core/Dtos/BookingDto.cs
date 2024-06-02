using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public Guid TenantId { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }
    }
}
