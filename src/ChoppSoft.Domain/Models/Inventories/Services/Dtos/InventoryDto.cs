namespace ChoppSoft.Domain.Models.Inventories.Services.Dtos
{
    public record InventoryDto(Guid productid,
                               Guid warehouseid,
                               decimal quantity);
}
