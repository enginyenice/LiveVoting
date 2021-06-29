using DataAccess.Abstract;
using Entities;
using Entities.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class AnswerDal : IAnswerDal
    {
        private readonly IMongoCollection<Answer> _collection;

        public AnswerDal(MongoSettings mongoSettings)
        {
            var client = new MongoClient(mongoSettings.ConnectionString);
            var database = client.GetDatabase(mongoSettings.DatabaseName);
            _collection = database.GetCollection<Answer>(mongoSettings.AnswerCollectionName);
        }

        public async Task CreateAsync(Answer answer)
        {
            await _collection.InsertOneAsync(answer);
        }

        public async Task CreateListAsync(List<Answer> answers)
        {
            await _collection.InsertManyAsync(answers);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(p => p.Id == id);
        }

        public async Task<Answer> GetAnswerByIdAsync(string id)
        {
            var answer = await _collection.FindAsync(p => p.Id == id);
            return answer.FirstOrDefault();
        }

        public async Task<List<Answer>> GetAnswerByQuestionIdAsync(string questionId)
        {
            var answers = await _collection.FindAsync(p => p.QuestionId == questionId);
            return await answers.ToListAsync();
        }

        public Task UpdateAsync(Answer answer)
        {
            throw new NotImplementedException();
        }

        // TODO: Daha generic bir çözüm bulunacak +1 yerine
        public async Task VoteAsync(Answer answer)
        {
            answer.Vote++;
            await _collection.FindOneAndReplaceAsync(p => p.Id == answer.Id, answer);
        }
    }
}