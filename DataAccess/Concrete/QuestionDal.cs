using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class QuestionDal : IQuestionDal
    {
        public Task CreateAsync(Question question)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Question>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetQuestionById(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
