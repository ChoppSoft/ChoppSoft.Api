using ChoppSoft.Domain.Interfaces.Warehouses;
using ChoppSoft.Domain.Models.Warehouses;
using ChoppSoft.Domain.Models.Warehouses.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Warehouses.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<ServiceResult> Create(WarehouseDto dto)
        {
            var warehouse = new Warehouse(dto.description, dto.location);

            await _warehouseRepository.Add(warehouse);

            return ServiceResult.Successful(new
            {
                WarehouseId = warehouse.Id,
                Message = "Almoxarifado cadastrado com sucesso."
            });
        }

        public async Task<ServiceResult> Update(Guid id, WarehouseDto dto)
        {
            var warehouse = await _warehouseRepository.GetById(id);

            if (warehouse is null)
                return ServiceResult.Failed($"Não foi possível encontrar o produto de código {id}");

            warehouse.Update(dto);

            await _warehouseRepository.Update(warehouse);

            return ServiceResult.Successful(new
            {
                WarehouseId = warehouse.Id,
                Message = "Almoxarifado atualizado com sucesso."
            });
        }

        public async Task<ServiceResult> GetAll(int page, int pageSize)
        {
            var warehouses = await _warehouseRepository.GetAll(page, pageSize, "Products");

            return ServiceResult.Successful(warehouses);
        }

        public async Task<ServiceResult> GetById(Guid id)
        {
            var warehouse = await _warehouseRepository.GetByIdAsync(id, "Products");

            return ServiceResult.Successful(warehouse);
        }

        public async Task<ServiceResult> Active(Guid id)
        {
            var warehouse = await _warehouseRepository.GetById(id);

            if (warehouse is null)
                return ServiceResult.Failed($"Não foi possível encontrar o produto de código {id}");

            warehouse.Activate();

            await _warehouseRepository.Update(warehouse);

            return ServiceResult.Successful(new
            {
                WarehouseId = warehouse.Id,
                Message = "Almoxarifado ativado com sucesso."
            });
        }

        public async Task<ServiceResult> Inactivate(Guid id)
        {
            var warehouse = await _warehouseRepository.GetById(id);

            if (warehouse is null)
                return ServiceResult.Failed($"Não foi possível encontrar o produto de código {id}");

            warehouse.Disable();

            await _warehouseRepository.Update(warehouse);

            return ServiceResult.Successful(new
            {
                WarehouseId = warehouse.Id,
                Message = "Almoxarifado desabilitado com sucesso."
            });
        }

        public async Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize)
        {
            var totalCount = await _warehouseRepository.TotalCount();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            return (totalCount, totalPages);
        }
    }
}
