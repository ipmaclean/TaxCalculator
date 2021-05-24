using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class Tax
    {
        [Required(ErrorMessage = "Please enter your annual gross income into the field")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Your annual gross income must be greater than {1}.")]
        [DataType(DataType.Currency)]
        public int GrossEarnings { get; set; }
        [DataType(DataType.Currency)]
        public double NetEarnings { get; set; }
        [DataType(DataType.Currency)]
        public double IncomeTax { get; set; }
        [DataType(DataType.Currency)]
        public double NIC { get; set; }
        [DataType(DataType.Currency)]
        public double TaxFreeAllowance { get; set; } = 12500;

        public void CalculateTax()
        {
            double taxableIncome = GrossEarnings;

            if (GrossEarnings <= 100000)
            {
                taxableIncome -= TaxFreeAllowance;

                if (taxableIncome <= 0)
                {
                    IncomeTax = 0;
                }
                else if (taxableIncome <= 37500)
                {
                    IncomeTax = taxableIncome * 0.2;
                }
                else
                {
                    IncomeTax = 37500 * 0.2;
                    IncomeTax += (taxableIncome - 37500) * 0.4;
                }
            }
            else if (GrossEarnings <= 125000)
            {
                TaxFreeAllowance -= (GrossEarnings - 100000) / 2;
                taxableIncome -= TaxFreeAllowance;
                IncomeTax = 37500 * 0.2;
                IncomeTax += (taxableIncome - 37500) * 0.4;
            }
            else
            {
                TaxFreeAllowance = 0;
                if (taxableIncome <= 150000)
                {
                    IncomeTax = 37500 * 0.2;
                    IncomeTax += (taxableIncome - 37500) * 0.4;
                }
                else
                {
                    IncomeTax = 37500 * 0.2;
                    IncomeTax += (150000 - 37500) * 0.4;
                    IncomeTax += (taxableIncome - 150000) * 0.45;
                }
            }
            NetEarnings = GrossEarnings - IncomeTax;
        }

        public void CalculateNIC()
        {
            double NICableIncome = GrossEarnings;
            double WeeklyNICableIncome = NICableIncome / 52;

            if (WeeklyNICableIncome < 183)
            {
                NIC = 0;
            }
            else if (WeeklyNICableIncome <= 962)
            {
                NIC = (NICableIncome - 183 * 52) * 0.12;
            }
            else
            {
                NIC = (962 - 183) * 52 * 0.12;
                NIC += (NICableIncome - 962 * 52) * 0.02; ;
            }

            NetEarnings -= NIC;
        }
    }
    
    
}