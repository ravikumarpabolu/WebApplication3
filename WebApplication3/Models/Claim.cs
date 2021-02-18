using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Claim
    {
       
        public int MemberId { get; set; }
        public DateTime ClaimDate { get; set; }
        public double ClaimAmount { get; set; }
    }
}
