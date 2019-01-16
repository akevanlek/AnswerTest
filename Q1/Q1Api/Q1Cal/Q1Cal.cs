using Q1Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q1Api
{
    public class Q1Cal
    {
        public List<Loan> CalulateLoan(double principle, double interest, int year)
        {
            List<Loan> response = new List<Loan>();
            double newPrinciple = 0;

            for (int i = 1; i <= year; i++)
            {
                if (i == 1)
                {
                    newPrinciple = principle;
                }
                var totalInterrest = newPrinciple * interest / 100;
                Loan newloan = new Loan()
                {
                    Year = i,
                    Interest = interest,
                    TotalInterest = totalInterrest,
                    Principle = newPrinciple,
                    PayPerYear = newPrinciple + totalInterrest,
                };
                
                newPrinciple = newloan.PayPerYear;

                response.Add(newloan);
            }
            return response;
        }
    }
}
