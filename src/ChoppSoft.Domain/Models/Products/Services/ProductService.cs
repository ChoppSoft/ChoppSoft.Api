﻿using ChoppSoft.Domain.Interfaces.Products;
using ChoppSoft.Domain.Models.Products.Services.Dtos;
using ChoppSoft.Domain.Models.Products.Services.Validators;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ServiceResult> Create(ProductDto dto)
        {
            var product = new Product(dto.identifier, 
                                      dto.description,
                                      dto.brand,
                                      dto.capacity,
                                      dto.price,
                                      dto.cost);

            var validationResult = new ProductCreateValidator().Validate(product);

            if (!validationResult.IsValid)
                return ServiceResult.Failed(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

            await _productRepository.Add(product);

            return ServiceResult.Successful(new
            {
                ProductId = product.Id,
                Message = "Produto cadastrado com sucesso."
            });
        }

        public async Task<ServiceResult> Update(Guid id, ProductDto dto)
        {
            var product = await _productRepository.GetById(id);

            if (product is null)
                return ServiceResult.Failed($"Não foi possível encontrar o produto de código {id}");

            product.Update(dto);

            var validationResult = new ProductUpdateValidator().Validate(product);

            if (!validationResult.IsValid)
                return ServiceResult.Failed(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

            await _productRepository.Update(product);

            return ServiceResult.Successful(new
            {
                ProductId = product.Id,
                Message = "Produto atualizado com sucesso."
            });
        }

        public async Task<ServiceResult> GetAll(QueryParams query)
        {
            var products = await _productRepository.GetAllWithFilters(query, "Suppliers");

            return ServiceResult.Successful(products);
        }

        public async Task<ServiceResult> GetById(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id, "Suppliers");

            return ServiceResult.Successful(product);
        }

        public async Task<ServiceResult> Active(Guid id)
        {
            var product = await _productRepository.GetById(id);

            if (product is null)
                return ServiceResult.Failed($"Não foi possível encontrar o produto de código {id}");

            product.Activate();

            await _productRepository.Update(product);

            return ServiceResult.Successful(new
            {
                ProductId = product.Id,
                Message = "Produto ativado com sucesso."
            });
        }

        public async Task<ServiceResult> Inactivate(Guid id)
        {
            var product = await _productRepository.GetById(id);

            if (product is null)
                return ServiceResult.Failed($"Não foi possível encontrar o produto de código {id}");

            product.Disable();

            await _productRepository.Update(product);

            return ServiceResult.Successful(new
            {
                ProductId = product.Id,
                Message = "Produto desabilitado com sucesso."
            });
        }

        public async Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize)
        {
            var totalCount = await _productRepository.TotalCount();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            return (totalCount, totalPages);
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}
