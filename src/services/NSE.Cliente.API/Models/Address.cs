using System;
namespace NSE.Cliente.API.Models
{
	public class Address : Entity
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string Cep { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public Guid ClientId { get; private set; }

        public Client Client { get; private set; }


        public Address(string street,
            string number,
            string complement,
            string neighborhood,
            string cep,
            string city,
            string state)
        {
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            Cep = cep;
            City = city;
            State = state;
        }
    }


}

