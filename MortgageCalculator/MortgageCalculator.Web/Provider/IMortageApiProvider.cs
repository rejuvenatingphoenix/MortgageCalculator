using System.Collections.Generic;
using System.Threading.Tasks;
using MortgageCalculator.Dto;

namespace MortgageCalculator.Web.Provider
{
    public interface IMortageApiProvider
    {
        IEnumerable<Mortgage>  GetMortgages();
        LoanDetails GetLoanRepaymentDetails(LoanDetails loanDetails);
        
    }
}