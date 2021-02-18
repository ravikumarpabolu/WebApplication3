using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
