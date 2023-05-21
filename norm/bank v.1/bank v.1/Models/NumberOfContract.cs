

namespace Bank.Models
{
    public class NumberOfContract
    {
        public int Id { get; set; }
        public int statementId { get; set; }
        public DateTime dateOfcontract { get; set; }
        public int EmployeeId { get; set; }
        public int ChartNumberId { get; set; }

        public Employee Employee { get; set; }

        public ChartNumber ChartNumber { get; set; }






    }
}
