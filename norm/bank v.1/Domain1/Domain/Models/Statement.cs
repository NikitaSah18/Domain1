
namespace Bank.Domain
{
    public class Statement
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public int sum { get; set; }
        public string currency { get; set; }
        public int ClientId { get; set; }

        public int ViewId { get; set; }

        public Client Client { get; set; }

        public View View { get; set; }

       

    

    }
}
