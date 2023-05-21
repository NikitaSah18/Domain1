namespace Bank.Domain
{
    public class ChartNumber
    {
        public int Id { get; set; }
        public DateTime dateOfchart { get; set; }
        public string procent { get; set; }

        public decimal debt { get; set; }
    }
}
