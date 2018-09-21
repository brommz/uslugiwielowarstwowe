using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.Models
{
    public class SimplePollAnswer
    {
        public Guid Id { get; set; }
        public Guid SimplePollOptionId { get; set; }
        public string EmployeeName { get; set; }
    }
}
