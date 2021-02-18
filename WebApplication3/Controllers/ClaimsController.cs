using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {


            return Ok();

        }

        // GET api/values/5
        [HttpGet("{claimId}/{ClaimDate}")]
        //[Route("api/[controller/GetClaims]")]
        public ActionResult<string> Get(int claimId, string claimDate)
        {

            return Ok(GetMemberClaims(claimId, Convert.ToDateTime(claimDate)));
        }

        [HttpGet("{claimId}")]
        //[Route("api/[controller/GetClaims]")]
        public ActionResult<string> Get(int claimId)
        {

            return Ok(GetMemberClaims(claimId,null));
        }

        // GET api/values/5
        [HttpGet("{memberId}")]
        public ActionResult<string> Get(int memberId, int claimId)
        {
            return Ok(GetMembers(memberId));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private List<MemberClaims> GetMemberClaims(int MemberId, DateTime? claimDate)
        {
            var memberList = GetMembers(MemberId);

            Claim claim1 = new Claim
            {
                MemberId = 1123,
                ClaimAmount = 1112.56,
                ClaimDate = Convert.ToDateTime("10/06/2020")
            };
            Claim claim2 = new Claim
            {
                MemberId = 1245,
                ClaimAmount = 67.54,
                ClaimDate = Convert.ToDateTime("12/05/2020")
            };

            Claim claim3 = new Claim
            {
                MemberId = 1245,
                ClaimAmount = 150.34,
                ClaimDate = Convert.ToDateTime("12/15/2020")
            };
            List<Claim> listClaims = new List<Claim>
            {
                claim1,
                claim2,
                claim3
            };

            List<Claim> memberClaims = new List<Claim>();

            if(claimDate!= null)
                memberClaims = listClaims.FindAll(x => x.MemberId == MemberId && x.ClaimDate <= claimDate );
            else
                memberClaims = listClaims.FindAll(x => x.MemberId == MemberId) ;

            
            var results = memberClaims.Select(c => new MemberClaims
            {
                FirstName = memberList.FirstOrDefault(x => x.MemberId == c.MemberId).FirstName,
                LastName = memberList.FirstOrDefault(x => x.MemberId == c.MemberId).LastName,
                EnrollmentDate = memberList.FirstOrDefault(x => x.MemberId == c.MemberId).EnrollmentDate,
                ClaimDate = c.ClaimDate,
                MemberId = MemberId
            }).ToList();

            return results;
        }


        private List<Member> GetMembers(int MemberId)
        {
            Member m1 = new Member
            {
                MemberId = 1123,
                EnrollmentDate = Convert.ToDateTime("9/1/2020"),
                FirstName = "John",
                LastName = "Doe"
            };
            Member m2 = new Member
            {
                MemberId = 1245,
                EnrollmentDate = Convert.ToDateTime("10/3/2020"),
                FirstName = "Jane",
                LastName = "Doe"
            };

            List<Member> listMembers = new List<Member>
            {
                m1,
                m2
            };

            return listMembers.FindAll(x => x.MemberId == MemberId);

        }


    }
}
