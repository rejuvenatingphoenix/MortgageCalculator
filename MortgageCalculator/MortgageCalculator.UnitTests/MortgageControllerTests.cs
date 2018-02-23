using MortgageCalculator.Dto;
using MortgageCalculator.Web.Controllers;
using MortgageCalculator.Web.Provider;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;
using MortgageCalculator.Web.Helpers;

namespace MortgageCalculator.UnutTests
{
    [TestFixture]
 public   class MortgageControllerTests
    {

        private readonly IMortageApiProvider _mortageApiProvider;
        private readonly IApiClientHelper _iApiClientHelper;

        public MortgageControllerTests()
        {
            _mortageApiProvider = Substitute.For<IMortageApiProvider>();
            _iApiClientHelper = Substitute.For<IApiClientHelper>();
        }
  
        [Test]
        public void GetMortgagesTest_Returns_View()
        {
             List<Dto.Mortgage> Mortgagelist = new List<Dto.Mortgage>();
            _mortageApiProvider.GetMortgages().Returns(Mortgagelist);
            var controller = new MortgageController(_mortageApiProvider);
            ViewResult viewResult = controller.GetListofMortgages() as ViewResult;
            Assert.That(viewResult, Is.Not.Null, "Controller returned view");
            Assert.IsNotNull(viewResult);
        }

        [Test]
        public void GetMortgagesTest_Returns_Mortgages()
        {
            List<Dto.Mortgage> Mortgagelist = new List<Dto.Mortgage>();
            _mortageApiProvider.GetMortgages().Returns(Mortgagelist);
            var controller = new MortgageController(_mortageApiProvider);
            ViewResult viewResult = controller.GetListofMortgages() as ViewResult;
            Assert.AreEqual(Mortgagelist, viewResult.Model);
        }

        [Test]
        public void GetLoanRepaymentDetails_Returns_LoanDetails()
        {
           LoanDetails loanDetails = new LoanDetails();
            _mortageApiProvider.GetLoanRepaymentDetails(loanDetails).Returns(loanDetails);
            var controller = new MortgageController(_mortageApiProvider);
            PartialViewResult viewResult = controller.GetLoanRepaymentDetails(loanDetails) as PartialViewResult;
            Assert.AreEqual(loanDetails, viewResult.Model);
        }
    }
}
