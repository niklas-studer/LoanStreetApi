namespace LoanStreetApi
{
    public class Loan
    {
        public Guid? id { get; set; }
        public decimal Amount { get; set; }

        public decimal IntrestRate { get; set; }

        public int LoanDurationInMonths { get; set; }

        public decimal MonthlyPaymentAmount { get; set; }
    }
}