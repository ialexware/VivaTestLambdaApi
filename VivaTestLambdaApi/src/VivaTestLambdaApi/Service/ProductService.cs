using AutoMapper;
using VivaTestLambdaApi.Contracts.Models;
using VivaTestLambdaApi.Repositories;
using FluentValidation;
using FluentValidation.Results;
using VivaTestLambdaApi.Contracts.Dto;
using VivaTestLambdaApi.Mapping;
using VivaTestLambdaApi.Contracts.Request;

namespace VivaTestLambdaApi.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository customerRepository)
        {
            _productRepository = customerRepository;
        }

        public async Task<bool> CreateAsync(Product product)
        {
            var existingUser = await _productRepository.GetAsync(product.Id.Value);
            if (existingUser is not null)
            {
                var message = $"A producto with id {product.Id} already exists";
                throw new ValidationException(message, new[]
                {
                new ValidationFailure(nameof(Product), message)
            });
            }

            ProductDto productDto = product.ToProductDto();

            return await _productRepository.CreateAsync(productDto);
        }

        public async Task<Product?> GetAsync(Guid id)
        {
            ProductDto? productDto = await _productRepository.GetAsync(id);
            return productDto?.ToProduct();
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            ProductDto productDto = product.ToProductDto();
            return await _productRepository.UpdateAsync(productDto);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }
}
