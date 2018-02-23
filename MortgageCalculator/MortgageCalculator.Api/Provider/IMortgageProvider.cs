using MortgageCalculator.Dto;
using System.Collections.Generic;

namespace MortgageCalculator.Api.Provider
{
    public interface IMortgageProvider
    {
        List<Mortgage> GetAllMortgages();
         LoanDetails  GetLoanRepaymentDetails(LoanDetails loanDetails);
    }
}
