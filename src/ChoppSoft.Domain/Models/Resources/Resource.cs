using ChoppSoft.Domain.Models.Resources.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Resources
{
    public class Resource : Entity
    {
        public Resource() { }

        public Resource(string description, 
                        string model, 
                        string licensePlate, 
                        decimal capacity,
                        bool isOwned)
        {
            Description = description;
            Model = model;
            LicensePlate = licensePlate;
            Capacity = capacity;
            IsOwned = isOwned;
        }

        public string Description { get; private set; }
        public string Model { get; private set; }
        public string LicensePlate { get; private set; }
        public decimal Capacity { get; private set; }
        public bool IsOwned { get; private set; } = true;

        internal void Update(ResourceDto dto)
        {
            Model = dto.model;
            LicensePlate = dto.licenseplate;
            Capacity = dto.capacity;
            IsOwned = dto.isowned;
        }
    }
}
