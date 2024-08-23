using Mango.Services.ShppingCartAPI.Models.Dto;

namespace Mango.Services.ShppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
    }
}
