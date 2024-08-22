
using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto> LoginAsync(LoginRequestDto loginRequest);
        Task<ResponseDto> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
    }
}
