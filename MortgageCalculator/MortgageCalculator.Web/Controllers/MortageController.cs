using MortgageCalculator.Dto;
using MortgageCalculator.Web.Helpers;
using MortgageCalculator.Web.Provider;
using System.Web.Caching;
using System.Web.Mvc;


namespace MortgageCalculator.Web.Controllers
{
    [ExceptionFilter]
    public class MortgageController : Controller
    {
        private readonly IMortageApiProvider _iMortageApiProvider;
        public MortgageController(IMortageApiProvider iMortageApiProvider)
        {
            _iMortageApiProvider = iMortageApiProvider;
        }

       [OutputCache(Location = System.Web.UI.OutputCacheLocation.Server, CacheProfile = "Mortgages")]
        [HttpGet]
        public ActionResult GetListofMortgages()
        {
            var mortgages = _iMortageApiProvider.GetMortgages();
            return View("GetMortgages", mortgages);
        }

        [HttpPost]
        public ActionResult GetLoanRepaymentDetails(LoanDetails loandetails)
        {
            var loanResult = _iMortageApiProvider.GetLoanRepaymentDetails(loandetails);
            return PartialView("~/Views/Mortgage/LoanRepaymentDetails.cshtml", loanResult);
        }

        public ActionResult LoanRepaymentDetails(decimal intertestRate)
        {
            LoanDetails loandetails = new LoanDetails();
            ViewBag.InterestRate = intertestRate;
            return View(loandetails);
        }

    }
}

    

