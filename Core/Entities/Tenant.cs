using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
