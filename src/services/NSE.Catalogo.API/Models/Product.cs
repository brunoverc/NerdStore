using System;
using NSE.Core.DomainObjects;

namespace NSE.Catalogo.API.Models
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public decimal Value { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Image { get; set; }
        public int QuantityStock { get; set; }
    }
}
