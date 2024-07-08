using ChoppSoft.Domain.Interfaces.Suppliers;
using ChoppSoft.Domain.Models.Suppliers.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Suppliers.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public async Task<ServiceResult> Create(SupplierDto dto)
        {
            var supplier = new Supplier(dto.name,
                                        dto.contactname,
                                        dto.email,
                                        dto.phonenumber);

            await _supplierRepository.Add(supplier);

            return ServiceResult.Successful(new
            {
                SupplierId = supplier.Id,
                Message = "Fornecedor cadastrado com sucesso."
            });
        }

        public async Task<ServiceResult> Update(Guid id, SupplierDto dto)
        {
            var supplier = await _supplierRepository.GetById(id);

            if (supplier is null)
                return ServiceResult.Failed($"Não foi possível encontrar o fornecedor de código {id}");

            supplier.Update(dto);

            await _supplierRepository.Update(supplier);

            return ServiceResult.Successful(new
            {
                SupplierId = supplier.Id,
                Message = "Fornecedor atualizado com sucesso."
            });
        }

        public async Task<ServiceResult> GetAll(int page, int pageSize)
        {
            var suppliers = await _supplierRepository.GetAll(page, pageSize);

            return ServiceResult.Successful(suppliers);
        }

        public async Task<ServiceResult> GetById(Guid id)
        {
            var supplier = await _supplierRepository.GetById(id);

            return ServiceResult.Successful(supplier);
        }

        public async Task<ServiceResult> Active(Guid id)
        {
            var supplier = await _supplierRepository.GetById(id);

            if (supplier is null)
                return ServiceResult.Failed($"Não foi possível encontrar o fornecedor de código {id}");

            supplier.Activate();

            await _supplierRepository.Update(supplier);

            return ServiceResult.Successful(new
            {
                SupplierId = supplier.Id,
                Message = "Fornecedor ativado com sucesso."
            });
        }

        public async Task<ServiceResult> Inactivate(Guid id)
        {
            var supplier = await _supplierRepository.GetById(id);

            if (supplier is null)
                return ServiceResult.Failed($"Não foi possível encontrar o fornecedor de código {id}");

            supplier.Disable();

            await _supplierRepository.Update(supplier);

            return ServiceResult.Successful(new
            {
                SupplierId = supplier.Id,
                Message = "Fornecedor desabilitado com sucesso."
            });
        }

        public async Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize)
        {
            var totalCount = await _supplierRepository.TotalCount();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            return (totalCount, totalPages);
        }

        public void Dispose()
        {
            _supplierRepository?.Dispose();
        }
    }
}
