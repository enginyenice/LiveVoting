using DataAccess.Abstract;
using Entities;
using Entities.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class IpAdressDal : IIpAdressDal
    {
        private readonly IMongoCollection<IpAdress> _collection;
        public IpAdressDal(MongoSettings mongoSettings)
        {
            var client = new MongoClient(mongoSettings.ConnectionString);
            var database = client.GetDatabase(mongoSettings.DatabaseName);
            _collection = database.GetCollection<IpAdress>(mongoSettings.IpAdressCollectionName);
        }

        public async Task<bool> CheckIfIpAdress(string questionId, string ipAdress)
        {
            var result = await _collection.FindAsync(p => p.QuestionId == questionId && p.Adress == ipAdress);
            return (await result.FirstOrDefaultAsync() != null) ? true:false;
        }

        public async Task CreatedAsync(IpAdress ipAdress)
        {
            await _collection.InsertOneAsync(ipAdress);
        }

        public  async Task<IpAdress> GetIpAdressByQuestionId(string questionId)
        {
            var ipAdress = await _collection.FindAsync(p => p.QuestionId == questionId);
            return await ipAdress.FirstOrDefaultAsync();
        }
    }
}
