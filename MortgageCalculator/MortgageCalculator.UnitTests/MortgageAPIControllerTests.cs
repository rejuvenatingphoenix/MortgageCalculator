using MortgageCalculator.Api.Controllers;
using MortgageCalculator.Api.Provider;
using MortgageCalculator.Api.Repository;
using MortgageCalculator.Dto;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace MortgageCalculator.API.UnitTest
{
    [TestFixture]
    public class MortgageCalculatorAPIUnitTest
    {
        private readonly IMortgageProvider _mortgageProvider;
        private readonly IMortgageRepository _mortgageRepository;

        public MortgageCalculatorAPIUnitTest()
        {
            _mortgageProvider = Substitute.For<IMortgageProvider>();
            _mortgageRepository = Substitute.For<IMortgageRepository>();
        }

        [Test]
        public void GetMortgagesTest_Returns_Mortgages_From_API()
        {
            List<Dto.Mortgage> Mortgagelist = new List<Dto.Mortgage>();
             _mortgageProvider.GetAllMortgages().Returns(Mortgagelist);
            var controller = new MortgageAPIController(_mortgageProvider);
            var resultfromAPI = controller.GetAllMortgages() as List<Dto.Mortgage>;
            Assert.AreEqual(Mortgagelist, resultfromAPI);
        }

        [Test]
        public void GetLoanRepaymentDetails_Returns_LoanDetails()
        {
            LoanDetails loanDetails = new LoanDetails();
            _mortgageProvider.GetLoanRepaymentDetails(loanDetails).Returns(loanDetails);
            var controller = new MortgageAPIController(_mortgageProvider);
            var result = controller.GetLoanRepaymentDetails(loanDetails) as LoanDetails;
            Assert.AreEqual(loanDetails, result);
        }

    }
}