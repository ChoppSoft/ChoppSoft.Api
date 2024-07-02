using ChoppSoft.Domain.Interfaces.Addresses;
using ChoppSoft.Domain.Models.Addresses.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Addresses.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<ServiceResult> Create(AddressDto dto)
        {
            var address = new Address(dto.customerid,
                                      dto.street,
                                      dto.number,
                                      dto.additionalinformation,
                                      dto.district,
                                      dto.city,
                                      dto.state,
                                      dto.postalcode,
                                      dto.country);

            await _addressRepository.Add(address);

            return ServiceResult.Successful(new
            {
                AddressId = address.Id,
                Message = "Endereço cadastrado com sucesso."
            });
        }

        public async Task<ServiceResult> Update(Guid id, AddressDto dto)
        {
            var address = await _addressRepository.GetById(id);

            if (address == null)
                return ServiceResult.Failed($"Não foi possível encontrar o endereço de código {id}");

            address.Update(dto);

            await _addressRepository.Update(address);

            return ServiceResult.Successful(new
            {
                AddressId = address.Id,
                Message = "Endereço atualizado com sucesso."
            });
        }

        public async Task<ServiceResult> GetAll(int page, int pageSize)
        {
            var address = await _addressRepository.GetAll(page, pageSize, "Customer");

            return ServiceResult.Successful(address);
        }

        public async Task<ServiceResult> GetById(Guid id)
        {
            var address = await _addressRepository.GetByIdAsync(id, "Customer");

            return ServiceResult.Successful(address);
        }

        public async Task<ServiceResult> SetAsDefault(Guid id)
        {
            var address = await _addressRepository.GetById(id);

            if (address == null)
                return ServiceResult.Failed($"Não foi possível encontrar o endereço de código {id}");

            address.SetAsDefault();

            await _addressRepository.Update(address);

            return ServiceResult.Successful(new
            {
                AddressId = address.Id,
                Message = "Endereco definido como padrão."
            });
        }

        public async Task<ServiceResult> Active(Guid id)
        {
            var address = await _addressRepository.GetById(id);

            if (address == null)
                return ServiceResult.Failed($"Não foi possível encontrar o endereço de código {id}");

            address.Activate();

            await _addressRepository.Update(address);

            return ServiceResult.Successful(new
            {
                AddressId = address.Id,
                Message = "Endereco ativado com sucesso."
            });
        }

        public async Task<ServiceResult> Inactivate(Guid id)
        {
            var address = await _addressRepository.GetById(id);

            if (address == null)
                return ServiceResult.Failed($"Não foi possível encontrar o endereço de código {id}");

            address.Disable();

            await _addressRepository.Update(address);

            return ServiceResult.Successful(new
            {
                AddressId = address.Id,
                Message = "Endereço desabilitado com sucesso."
            });
        }
    }
}
