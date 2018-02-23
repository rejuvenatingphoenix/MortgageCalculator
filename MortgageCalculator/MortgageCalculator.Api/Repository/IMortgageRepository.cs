using MortgageCalculator.Dto;
using System.Collections.Generic;

namespace MortgageCalculator.Api.Repository
{
    public interface IMortgageRepository
    {
        List<Mortgage> GetAllMortgages();
        LoanDetails GetLoanRepaymentDetails(LoanDetails loanDetails);
    }
}
