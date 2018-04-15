namespace BuckIBooze.API.Models
{
    public class Order
    {
        public int Id {get;set;}
        public string fname {get; set;}
        public string lname {get; set;}
        public string phone {get; set;}
        public string email {get; set;}
        public int productID {get; set;}
        public int quantity {get; set;}
        public double total {get; set;}
        public int pickupNum {get; set;}


    }
}