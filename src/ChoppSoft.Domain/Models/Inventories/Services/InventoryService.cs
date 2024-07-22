using ChoppSoft.Domain.Interfaces.Inventories;
using ChoppSoft.Domain.Models.Inventories.Services.Dtos;
using ChoppSoft.Domain.Models.Inventories.Services.Validators;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Inventories.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<ServiceResult> Create(InventoryDto dto)
        {
            var inventory = new Inventory(dto.productid,
                                          dto.warehouseid,
                                          dto.quantity);

            var validationResult = new InventoryCreateValidator().Validate(inventory);

            if (!validationResult.IsValid)
                return ServiceResult.Failed(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

            await _inventoryRepository.Add(inventory);

            return ServiceResult.Successful(new
            {
                InventoryId = inventory.Id,
                Message = "Estoque cadastrado com sucesso."
            });
        }

        public async Task<ServiceResult> Update(Guid id, InventoryDto dto)
        {
            var inventory = await _inventoryRepository.GetById(id);

            if (inventory is null)
                return ServiceResult.Failed($"Não foi possível encontrar o estoque de código {id}");

            inventory.Update(dto);

            var validationResult = new InventoryUpdateValidator().Validate(inventory);

            if (!validationResult.IsValid)
                return ServiceResult.Failed(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

            await _inventoryRepository.Update(inventory);

            return ServiceResult.Successful(new
            {
                InventoryId = inventory.Id,
                Message = "Estoque atualizado com sucesso."
            });
        }

        public async Task<ServiceResult> GetAll(int page, int pageSize)
        {
            var inventorys = await _inventoryRepository.GetAll(page, pageSize, "Product", "Warehouse");

            return ServiceResult.Successful(inventorys);
        }

        public async Task<ServiceResult> GetById(Guid id)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(id, "Product", "Warehouse");

            return ServiceResult.Successful(inventory);
        }

        public async Task<ServiceResult> Active(Guid id)
        {
            var inventory = await _inventoryRepository.GetById(id);

            if (inventory is null)
                return ServiceResult.Failed($"Não foi possível encontrar o estoque de código {id}");

            inventory.Activate();

            await _inventoryRepository.Update(inventory);

            return ServiceResult.Successful(new
            {
                InventoryId = inventory.Id,
                Message = "Estoque ativado com sucesso."
            });
        }

        public async Task<ServiceResult> Inactivate(Guid id)
        {
            var inventory = await _inventoryRepository.GetById(id);

            if (inventory is null)
                return ServiceResult.Failed($"Não foi possível encontrar o produto de código {id}");

            inventory.Disable();

            await _inventoryRepository.Update(inventory);

            return ServiceResult.Successful(new
            {
                InventoryId = inventory.Id,
                Message = "Estoque desabilitado com sucesso."
            });
        }

        public async Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize)
        {
            var totalCount = await _inventoryRepository.TotalCount();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            return (totalCount, totalPages);
        }

        public void Dispose()
        {
            _inventoryRepository?.Dispose();
        }
    }
}
