
using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IBaseService
    {
         Task<ResponseDto?> SenAsync(RequestDto requestDto,bool withBearer = true);
    }
}
