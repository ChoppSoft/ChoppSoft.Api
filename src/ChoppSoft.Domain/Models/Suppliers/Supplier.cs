﻿using ChoppSoft.Domain.Models.Suppliers.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Suppliers
{
    public sealed class Supplier : Entity
    {
        public Supplier(string name, 
                        string contactName, 
                        string email, 
                        string phoneNumber)
        {
            Name = name;
            ContactName = contactName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Supplier() { }

        public string Name { get; private set; }
        public string ContactName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        internal void Update(SupplierDto dto)
        {
            Name = dto.name;
            ContactName = dto.contactname;
            Email = dto.email;
            PhoneNumber = dto.phonenumber;
        }
    }
}
