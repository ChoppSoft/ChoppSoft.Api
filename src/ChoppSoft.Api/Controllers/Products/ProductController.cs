using AutoMapper;
using ChoppSoft.Api.ViewModels;
using ChoppSoft.Domain.Models.Products.Services;
using ChoppSoft.Domain.Models.Products.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Products
{
    public class ProductController : ControllerSoftBase
    {
        private readonly IProductService _productService;
        public ProductController(IMapper mapper, 
                                 IProductService productService) : base(mapper)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            var response = await _productService.GetAll(page, pageSize);
            var pagination = await _productService.GetPagination(pageSize);

            return ReturnBase<ICollection<ProductViewModel>>(response, pagination.TotalCount, pagination.TotalPages);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _productService.GetById(id);

            return ReturnBase<ProductViewModel>(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto dto)
        {
            var response = await _productService.Create(dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ProductDto dto)
        {
            var response = await _productService.Update(id, dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/Active")]
        public async Task<IActionResult> Active([FromRoute] Guid id)
        {
            var response = await _productService.Active(id);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/Inactivate")]
        public async Task<IActionResult> Inactivate([FromRoute] Guid id)
        {
            var response = await _productService.Inactivate(id);

            return ReturnBase(response);
        }
    }
}
