using ChoppSoft.Domain.Interfaces.Routes;
using ChoppSoft.Domain.Models.Routes.Services.Dtos;
using ChoppSoft.Domain.Models.Routes.Services.Validators;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Routes.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;

        public RouteService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<ServiceResult> Create(RouteDto dto)
        {
            var route = new Route(dto.description, dto.resourceid);

            var validationResult = new RouteCreateValidator().Validate(route);

            if (!validationResult.IsValid)
                return ServiceResult.Failed("A validação falhou.", validationResult.Errors?.Select(e => e.ErrorMessage).ToList());

            await _routeRepository.Add(route);

            return ServiceResult.Successful(new
            {
                RouteId = route.Id,
                Message = "Rota cadastrada com sucesso."
            });
        }

        public async Task<ServiceResult> GetAll(QueryParams query)
        {
            var routes = await _routeRepository.GetAllWithFilters(query, "Stops", "Deliveries");

            return ServiceResult.Successful(routes);
        }

        public async Task<ServiceResult> GetById(Guid id)
        {
            var route = await _routeRepository.GetByIdAsync(id, "Stops", "Deliveries");

            return ServiceResult.Successful(route);
        }

        public async Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize)
        {
            var totalCount = await _routeRepository.TotalCount();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            return (totalCount, totalPages);
        }

        public void Dispose()
        {
            _routeRepository?.Dispose();
        }
    }
}
