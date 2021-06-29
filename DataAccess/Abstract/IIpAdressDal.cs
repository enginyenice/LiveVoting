using Entities;
using System;
using System.Collections.Generic;
using System.Text;
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
