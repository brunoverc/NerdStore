using System;

namespace NSE.WebApp.MVC.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public decimal Value { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Image { get; set; }
        public int StockQuantity { get; set; }
    }
}
