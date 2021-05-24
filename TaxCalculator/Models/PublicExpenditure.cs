using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class PublicExpenditure
    {
        [DataType(DataType.Currency)]
        public int Welfare { get; set; }
        [DataType(DataType.Currency)]
        public int Health { get; set; }
        [DataType(DataType.Currency)]
        public int Education { get; set; }
        [DataType(DataType.Currency)]
        public int NationalDebtInterest { get; set; }
        [DataType(DataType.Currency)]
        public int Defence { get; set; }
        [DataType(DataType.Currency)]
        public int Transport { get; set; }
        [DataType(DataType.Currency)]
        public int PublicOrderAndSafety { get; set; }
        [DataType(DataType.Currency)]
        public int BusinessAndIndustry { get; set; }
        [DataType(DataType.Currency)]
        public int GovernmentAdministration { get; set; }
        [DataType(DataType.Currency)]
        public int HousingAndUtilities { get; set; }
        [DataType(DataType.Currency)]
        public int Culture { get; set; }
        [DataType(DataType.Currency)]
        public int Environment { get; set; }
        [DataType(DataType.Currency)]
        public int OverseasAid { get; set; }
        [DataType(DataType.Currency)]
        public int EU { get; set; }
        [DataType(DataType.Currency)]
        public int StatePension { get; set; }

        public PublicExpenditure(double IncomeTax, double NIC)
        {
            Welfare = Convert.ToInt32(Math.Round((IncomeTax + NIC) * 0.221));
            Health = Convert.ToInt32(Math.Round((IncomeTax + NIC) * 0.205));
            StatePension = Convert.ToInt32(Math.Round((IncomeTax + NIC) * 0.124));
            Education = Convert.ToInt32(Math.Round((IncomeTax + NIC) * 0.116));
            NationalDebtInterest = Convert.ToInt32(Math.Round((IncomeTax + NIC) * 0.069));
            Defence = Convert.ToInt32(Math.Round((IncomeTax + NIC) * 0.053));
            Transport = Convert.ToInt32(Math.Round((IncomeTax + NIC) * 0.043));
            PublicOrderAndSafety = Convert.ToInt32(Math.Round((IncomeTax + NIC) * 0.043));
            BusinessAndIndustry = Convert.ToInt32(Math.Round((IncomeTax + NIC) * 0.038));
            GovernmentAdministration = Convert.ToInt32(Math.Round((IncomeTax + NIC) * 0.021));
            HousingAndUtilities = Convert.ToInt32(Math.Round((IncomeTax + NIC) * 0.018));
            Culture = Convert.ToInt32(Math.Round((IncomeTax + NIC) * 0.015));
            Environment = Convert.ToInt32(Math.Round((IncomeTax + NIC) * 0.015));
            OverseasAid = Convert.ToInt32(Math.Round((IncomeTax + NIC) * 0.011));
            EU = Convert.ToInt32(Math.Round((IncomeTax + NIC) * 0.008));
            
        }
    }
}