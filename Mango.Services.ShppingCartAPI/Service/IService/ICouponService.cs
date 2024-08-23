using Mango.Services.ShppingCartAPI.Models.Dto;

namespace Mango.Services.ShppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCouponAsync(string couponCode);
    }
}
