using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }
        public int Bedrooms { get; set; }
        public bool IsAvailable { get; set; }
    }
}
