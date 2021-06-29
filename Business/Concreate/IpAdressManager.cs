using AutoMapper;
using Business.Abstract;
using Core.Response;
using DataAccess.Abstract;
using Dtos.IpAdress;
using Entities;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class IpAdressManager : IIpAdressService
    {
        private readonly IIpAdressDal _ipAdressDal;
        private readonly IMapper _mapper;

        public IpAdressManager(IIpAdressDal ipAdressDal, IMapper mapper)
        {
            _ipAdressDal = ipAdressDal;
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> CreatedAsync(IpAdressDto ipAdressDto)
        {
            var ipAdress = _mapper.Map<IpAdress>(ipAdressDto);
            await _ipAdressDal.CreatedAsync(ipAdress);
            return Response<NoContent>.Success();
        }

        public async Task<Response<NoContent>> CheckIfIpAdress(string questionId, string ipAdress)
        {
            var result = await _ipAdressDal.CheckIfIpAdress(questionId, ipAdress);

            if (result)
            {
                return Response<NoContent>.Fail("Daha önceden bu ankete oy kullandınız");
            }
            return Response<NoContent>.Success();
        }
    }
}