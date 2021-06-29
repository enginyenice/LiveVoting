using DataAccess.Abstract;
using Entities;
using Entities.Settings;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class QuestionDal : IQuestionDal
    {
        private readonly IMongoCollection<Question> _collection;

        public QuestionDal(MongoSettings mongoSettings)
        {
            var client = new MongoClient(mongoSettings.ConnectionString);
            var database = client.GetDatabase(mongoSettings.DatabaseName);
            _collection = database.GetCollection<Question>(mongoSettings.QuestionCollectionName);
        }

        public async Task CreateAsync(Question question)
        {
            await _collection.InsertOneAsync(question);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(p => p.Id == id);
        }

        public async Task<List<Question>> GetAllAsync()
        {
            var questions = await _collection.Find(question => true).ToListAsync();
            if (!questions.Any())
            {
                return new List<Question>();
            }
            return questions;
        }

        public async Task<Question> GetQuestionByIdAsync(string id)
        {
            var question = await _collection.FindAsync(p => p.Id == id);
            return await question.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Question question)
        {
            var result = await _collection.FindOneAndReplaceAsync(p => p.Id == question.Id, question);
        }
    }
}