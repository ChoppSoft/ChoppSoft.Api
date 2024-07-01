using ChoppSoft.Domain.Interfaces.Customers;
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
    }
}
