﻿using ChoppSoft.Domain.Interfaces.Customers;
using ChoppSoft.Domain.Models.Customers.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Customers.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ServiceResult> Create(CustomerDto dto)
        {
            var customer = new Customer(dto.name, dto.document, dto.documenttype, dto.phonenumber, dto.email, dto.dateofbirth);

            await _customerRepository.Add(customer);

            return ServiceResult.Successful(new
            {
                CustomerId = customer.Id,
                Message = "Cliente cadastrado com sucesso."
            });
        }

        public async Task<ServiceResult> Update(Guid id, CustomerDto dto)
        {
            var customer = await _customerRepository.GetById(id);

            if (customer == null)
                return ServiceResult.Failed($"Não foi possível encontrar o cliente de código {id}");

            customer.Update(dto);

            await _customerRepository.Update(customer);

            return ServiceResult.Successful(new
            {
                CustomerId = customer.Id,
                Message = "Cliente atualizado com sucesso."
            });
        }

        public async Task<ServiceResult> GetAll(int page, int pageSize)
        {
            var customers = await _customerRepository.GetAll(page, pageSize, "Addresses");

            return ServiceResult.Successful(customers);
        }

        public async Task<ServiceResult> GetById(Guid id)
        {
            var customer = await _customerRepository.GetById(id, "Addresses");

            return ServiceResult.Successful(customer);
        }

        public async Task<ServiceResult> Active(Guid id)
        {
            var customer = await _customerRepository.GetById(id);

            if (customer == null)
                return ServiceResult.Failed($"Não foi possível encontrar o cliente de código {id}");

            customer.Activate();

            await _customerRepository.Update(customer);

            return ServiceResult.Successful(new
            {
                CustomerId = customer.Id,
                Message = "Cliente ativado com sucesso."
            });
        }

        public async Task<ServiceResult> Inactivate(Guid id)
        {
            var customer = await _customerRepository.GetById(id);

            if (customer == null)
                return ServiceResult.Failed($"Não foi possível encontrar o cliente de código {id}");

            customer.Disable();

            await _customerRepository.Update(customer);

            return ServiceResult.Successful(new
            {
                CustomerId = customer.Id,
                Message = "Cliente desabilitado com sucesso."
            });
        }

        public async Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize)
        {
            var totalCount = await _customerRepository.TotalCount();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            return (totalCount, totalPages);
        }
    }
}
