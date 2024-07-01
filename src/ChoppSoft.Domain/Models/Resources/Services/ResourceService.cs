using ChoppSoft.Domain.Interfaces.Resources;
using ChoppSoft.Domain.Models.Resources.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Resources.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;
        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public async Task<ServiceResult> Create(ResourceDto dto)
        {
            var resource = new Resource(dto.description,
                                        dto.model,
                                        dto.licenseplate,
                                        dto.capacity,
                                        dto.isowned);

            await _resourceRepository.Add(resource);

            return ServiceResult.Successful(new
            {
                ResourceId = resource.Id,
                Message = "Recurso cadastrado com sucesso."
            });
        }

        public async Task<ServiceResult> Update(Guid id, ResourceDto dto)
        {
            var resource = await _resourceRepository.GetById(id);

            if (resource == null)
                return ServiceResult.Failed($"Não foi possível encontrar o recurso de código {id}");

            resource.Update(dto);

            await _resourceRepository.Update(resource);

            return ServiceResult.Successful(new
            {
                ResourceId = resource.Id,
                Message = "Recurso atualizado com sucesso."
            });
        }

        public async Task<ServiceResult> GetAll(int page, int pageSize)
        {
            var resource = await _resourceRepository.GetAll(page, pageSize);

            return ServiceResult.Successful(resource);
        }

        public async Task<ServiceResult> GetById(Guid id)
        {
            var resource = await _resourceRepository.GetById(id);

            return ServiceResult.Successful(resource);
        }

        public async Task<ServiceResult> Active(Guid id)
        {
            var resource = await _resourceRepository.GetById(id);

            if (resource == null)
                return ServiceResult.Failed($"Não foi possível encontrar o recurso de código {id}");

            resource.Activate();

            await _resourceRepository.Update(resource);

            return ServiceResult.Successful(new
            {
                ResourceId = resource.Id,
                Message = "Recurso ativado com sucesso."
            });
        }

        public async Task<ServiceResult> Inactivate(Guid id)
        {
            var resource = await _resourceRepository.GetById(id);

            if (resource == null)
                return ServiceResult.Failed($"Não foi possível encontrar o recurso de código {id}");

            resource.Disable();

            await _resourceRepository.Update(resource);

            return ServiceResult.Successful(new
            {
                ResourceId = resource.Id,
                Message = "recurso desabilitado com sucesso."
            });
        }
    }
}
