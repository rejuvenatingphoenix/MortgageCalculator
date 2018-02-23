using MortgageCalculator.Api.Repository;
using MortgageCalculator.Dto;
using System.Collections.Generic;

namespace MortgageCalculator.Api.Provider
{
    public class MortgageProvider : IMortgageProvider
    {
        private readonly IMortgageRepository _mortgageRepository;
        public MortgageProvider(IMortgageRepository mortgageRepository)
        {
            _mortgageRepository = mortgageRepository;
        }
        /// <summary>
        /// Get All Active Mortgages
        /// </summary>
        /// <returns></returns>
        public List<Mortgage> GetAllMortgages()
        {
            return _mortgageRepository.GetAllMortgages();
        }

        /// <summary>
        ///  Get Loan Results by passing relevant values
        /// </summary>
        /// <param name="loanDetails"> Detail which contais loan amont,interest rate etc.</param>
        /// <returns> Calculated LoanRepayment,Total Interest Rate and passed loan details</returns>
        public LoanDetails GetLoanRepaymentDetails(LoanDetails loanDetails)
        {
            return _mortgageRepository.GetLoanRepaymentDetails(loanDetails);
        }
    }
}