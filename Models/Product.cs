namespace BuckIBooze.API.Models
{
    public class Product
    {
        public int Id {get;set;}
        public string name {get; set;}
        public int price { get; set;}
        public string size {get; set;}
        public string supertype {get; set;}
        public string subtype {get; set;}
        public string imgName {get; set;}
        public string imgURL {get; set;}
    }
}