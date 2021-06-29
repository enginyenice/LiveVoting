using Core.Response;
using Dtos.IpAdress;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IIpAdressService
    {
        Task<Response<NoContent>> CreatedAsync(IpAdressDto ipAdressDto);

        Task<Response<NoContent>> CheckIfIpAdress(string questionId, string ipAdress);
    }
}