using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q1Api.Models
{
    public class Loan
    {
        /// <summary>
        /// ปี
        /// </summary>
        public int Year { get; set; }
        ///// <summary>
        ///// คงค้าง
        ///// </summary>
        //public double Remain { get; set; }
        /// <summary>
        /// เงินต้น คงค้าง
        /// </summary>
        public double Principle { get; set; }
        /// <summary>
        /// อัตราดอกเบีย
        /// </summary>
        public double Interest { get; set; }
        /// <summary>
        /// ดอกเบียที่ต้องชำระ
        /// </summary>
        public double TotalInterest { get; set; }
        /// <summary>
        /// ยอดที่ต้องชำระ
        /// </summary>
        public double PayPerYear { get; set; }
        
    }
}
