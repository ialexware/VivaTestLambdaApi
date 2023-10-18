using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VivaTestLambdaApi.Contracts.Dto;
using VivaTestLambdaApi.Contracts.Models;
using VivaTestLambdaApi.Contracts.Request;
using VivaTestLambdaApi.Mapping;
using VivaTestLambdaApi.Service;

namespace VivaTestLambdaApi.Controllers
{
    [Route("api/products")]
    public class ProductControler : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ResponseDto _responseDto;


        public ProductControler(IProductService productService)
        {
            _productService = productService;
            _responseDto = new ResponseDto();
        }

        [HttpGet("{id}")]
        public async Task<ResponseDto> Get(Guid id)
        {
            try
            {
                var product = await _productService.GetAsync(id);
                if (product is null)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Product not found";
                }
                else
                {
                    var productResponse = product.ToCustomerResponse();
                    _responseDto.Result = productResponse;
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;

        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] CreateProductRequest productDto)
        {
            try
            {
                Product product = productDto.ToProduct();
                var created = await _productService.CreateAsync(product);

                if (created)
                {
                    _responseDto.IsSuccess = created;
                    _responseDto.Message = "Product created successfully";
                    _responseDto.Result = product.ToCustomerResponse();

                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] UpdateProductRequest req)
        {
            try
            {
                var existingCustomer = await _productService.GetAsync(req.Id);

                if (existingCustomer is null)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Product not found";
                }
                else
                {
                    Product product = req.ToProduct();
                    _responseDto.IsSuccess = await _productService.UpdateAsync(product);
                    _responseDto.Result = product.ToCustomerResponse();
                }

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(Guid Id)
        {
            try
            {
                var deleted = await _productService.DeleteAsync(Id);
                if (!deleted)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Product not found";
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;

        }
    }
}
