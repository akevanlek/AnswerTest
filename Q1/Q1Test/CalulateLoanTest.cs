using FluentAssertions;
using Q1Api;
using Q1Api.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Q1Test
{
    public class CalulateLoanTest
    {
        [Fact]
        public void CalulateLoanSuccess()
        {
            var q1cal = new Q1Cal();
            var result = q1cal.CalulateLoan(10000, 12, 3);


            List<Loan> expectedLoanResponse = new List<Loan>()
            {
                new Loan()
                {
                    Year =1,
                    Principle = 10000,
                    Interest = 12,
                    TotalInterest = 1200,
                    PayPerYear = 11200,
                },
                new Loan()
                {
                    Year =2,
                    Principle = 11200,
                    Interest = 12,
                    TotalInterest = 1344,
                    PayPerYear = 12544
                },
                new Loan()
                {
                    Year =3,
                    Principle = 12544,
                    Interest = 12,
                    TotalInterest = 1505.28,
                    PayPerYear = 14049.28
                },

            };


            result.Should().BeEquivalentTo(expectedLoanResponse);

        }
    }
}

