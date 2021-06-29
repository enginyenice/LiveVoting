using Entities;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IIpAdressDal
    {
        Task CreatedAsync(IpAdress ipAdress);

        Task<IpAdress> GetIpAdressByQuestionId(string questionId);

        Task<bool> CheckIfIpAdress(string questionId, string ipAdress);
    }
}