using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q1Api.Models;

namespace Q1Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        public static double Interest = 0;

        [HttpGet("GetInterest")]
        public InterestResponse GetInterest()
        {
            return new InterestResponse { Interest = Interest };
        }

        [HttpPost("SetInterest/{interest}")]
        public InterestResponse SetInterest(double interest)
        {
            Interest = interest;
            return new InterestResponse { Interest = Interest };
        }

        [HttpPost("Loan/{principle}/{year}")]
        public List<Loan> Loan(double principle, int year)
        {
            var q1Cal = new Q1Cal();

            var result = q1Cal.CalulateLoan(principle, Interest, year);
            return result;
        }
    }
}
