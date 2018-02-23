using System.ComponentModel.DataAnnotations;

namespace MortgageCalculator.Dto
{
    public    class LoanDetails
    {
        [Required]
        public decimal LoanAmount { get; set; }
        public decimal TotalRepaymentAmount { get; set; }
        public decimal InterestRate { get; set; }
        public decimal TotalInterest { get; set; }
        [Required]
        public int NoofYears { get; set; }


    }
}
