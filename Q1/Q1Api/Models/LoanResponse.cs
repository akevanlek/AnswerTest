using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q1Api.Models
{
    public class LoanResponse
    {
        public List<Loan> LoanResult { get; set; }

        public LoanResponse()
        {
            LoanResult = new List<Loan>();
        }
    }
}
