using System;
using NSE.Core.DomainObjects;

namespace NSE.Cliente.API.Models
{
	public class Client : Entity, IAggregateRoot
	{
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }

        public bool Deleted { get; private set; }
        public Address Address { get; private set; }

        public Client(Guid id, string name, string email, string cpf)
        {
            Id = id;
            Name = name;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
            Deleted = false;

        }

        public void ChangeEmail(string email)
        {
            Email = new Email(email);
        }

        public void SetAddress(Address address)
        {
            Address = address;
        }

        protected Client() { }
    }
}

