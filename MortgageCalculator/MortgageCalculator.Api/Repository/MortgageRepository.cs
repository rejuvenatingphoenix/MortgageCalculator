using MortgageCalculator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MortgageCalculator.Api.Repository
{
    public class MortgageRepository : IMortgageRepository
    {
        /// <summary>
        /// Get All mortages 
        /// </summary>
        /// <returns> List of Mortages</returns>
        public List<Mortgage> GetAllMortgages()
        {
            using (var context = new MortgageData.MortgageDataContext())
            {
                var mortgages = context.Mortgages.ToList();
                List<Mortgage> result = new List<Mortgage>();
                foreach (var mortgage in mortgages)
                {
                    result.Add(new Mortgage()
                    {
                        Name = mortgage.Name,
                        EffectiveStartDate = mortgage.EffectiveStartDate,
                        EffectiveEndDate = mortgage.EffectiveEndDate,
                        CancellationFee = mortgage.CancellationFee,
                        EstablishmentFee = mortgage.CancellationFee,
                        InterestRepayment = (InterestRepayment)Enum.Parse(typeof(InterestRepayment), mortgage.InterestRepayment.ToString()),
                        MortgageId = mortgage.MortgageId,
                        MortgageType = (MortgageType)Enum.Parse(typeof(MortgageType), mortgage.MortgageType.ToString()),
                        //TermsInMonths = mortgage.
                        InterestRate=mortgage.InterestRate
                    }
                    );
                }
                result.OrderBy(r => r.MortgageType).ThenBy(r => r.InterestRate);
                return result;
            }
        }
        /// <summary>
        /// Get Loan Repayment Details based on the Loan Amount, No of years and mortgage Type
        /// Assumption:- Irresepective of any mortgage type selected by user, only interest rate considered
        /// Calculation is done only for monthly payment (Principal+ interest payment) every month
        /// </summary>
        /// <param name="loandetails"></param>
        /// <returns></returns>
        public LoanDetails GetLoanRepaymentDetails(LoanDetails loandetails)
        {
            // rate of interest and number of payments for monthly payments
            var rateOfInterest = loandetails.InterestRate / 1200;
            var numberOfPayments = loandetails.NoofYears * 12;
            var paymentAmount = Convert.ToDouble((rateOfInterest * loandetails.LoanAmount)) / (1 - Math.Pow(Convert.ToDouble(1 + rateOfInterest), Convert.ToDouble(rateOfInterest * -1)));
            loandetails.TotalRepaymentAmount = Convert.ToDecimal(Math.Round(paymentAmount * numberOfPayments, 2));

            var beginning_Balance = loandetails.LoanAmount;
            var interest = beginning_Balance * ((loandetails.InterestRate / 100) / 12);
            var principal = Convert.ToDecimal(paymentAmount) - interest;
            var ending_Balance = beginning_Balance - principal;
            decimal TotalInterestAmount = 0;
            beginning_Balance = ending_Balance;
            TotalInterestAmount += interest;
            while (ending_Balance > 0)
            {
                interest = beginning_Balance * ((loandetails.InterestRate / 100) / 12);
                TotalInterestAmount += interest;
                principal = Convert.ToDecimal(paymentAmount) - interest;
                ending_Balance = beginning_Balance - principal;
                beginning_Balance = ending_Balance;
            }
            loandetails.TotalInterest = Math.Round(TotalInterestAmount,2);
            return loandetails;
            }
   
        }
    }
