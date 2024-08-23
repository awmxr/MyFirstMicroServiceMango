using System.Reflection.Metadata.Ecma335;

namespace Mango.Services.ShppingCartAPI.Models.Dto
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
