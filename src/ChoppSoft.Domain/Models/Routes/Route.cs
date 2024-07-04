using ChoppSoft.Domain.Models.Addresses;
using ChoppSoft.Domain.Models.Resources;
using ChoppSoft.Domain.Models.Routes.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Routes
{
    public sealed class Route : Entity
    {
        public Route(string description,
                     Guid resourceId)
        {
            Description = description;
            ResourceId = resourceId;
            Complete = false;
            Stops = new List<Address>();
        }

        public Route() { }

        public string Description { get; private set; }
        public Guid ResourceId { get; private set; }
        public bool Complete { get; private set; }

        public Resource Resource { get; private set; }
        public ICollection<Address> Stops { get; private set; }

        public void AddStop(Address address) => Stops.Add(address);

        public void AddStops(ICollection<Address> addresses)
        {
            foreach (var address in addresses) 
            {
                AddStop(address);
            }
        }

        public void IsComplete() => Complete = true;

        public void update(RouteDto dto)
        {
            Description = dto.description;
            ResourceId = dto.resourceid;
        }

    }
}
