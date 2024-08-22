using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateProductAsync(ProductDto productDto)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = productDto,
                URL = SD.ProductAPIBase + "/api/product"
            });
        }

        public async Task<ResponseDto?> DeleteProductAsync(int id)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                URL = SD.ProductAPIBase + "/api/product/" + id
            });
        }

        public async Task<ResponseDto?> GetAllProductAsync()
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                URL = SD.ProductAPIBase + "/api/product"
            });
        }

        public async Task<ResponseDto?> GetProductByIdAsync(int id)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                URL = SD.ProductAPIBase + "/api/product/" + id
            });
        }

        public async Task<ResponseDto?> UpdateProductAsync(ProductDto productDto)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDto,
                URL = SD.ProductAPIBase + "/api/product"
            });
        }
    }
}
