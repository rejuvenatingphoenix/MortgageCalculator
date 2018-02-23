using MortgageCalculator.Api.Helpers;
using MortgageCalculator.Api.Provider;
using MortgageCalculator.Dto;
using System.Collections.Generic;
using System.Web.Http;

namespace MortgageCalculator.Api.Controllers
{
    [RoutePrefix("api/Mortgage")]
    [APIExceptionFilter]
    public class MortgageAPIController : ApiController
    {
        private readonly IMortgageProvider  _iMortgageProvider ;
        public MortgageAPIController(IMortgageProvider iMortgageProvider)
        {
            _iMortgageProvider = iMortgageProvider;
        }

        [HttpGet]
       [Route("GetAllMortgages")]
        public IEnumerable<Dto.Mortgage> GetAllMortgages()
        {
            return _iMortgageProvider.GetAllMortgages();
        }

        [HttpPost]
        [Route("GetLoanRepaymentDetails")]
        public LoanDetails GetLoanRepaymentDetails(LoanDetails loanDetails)
        {
            return _iMortgageProvider.GetLoanRepaymentDetails(loanDetails);
        }
    }
}
