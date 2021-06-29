using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAnswerDal
    {
        Task CreateAsync(Answer answer);
        Task CreateListAsync(List<Answer> answers);
        Task UpdateAsync(Answer answer);
        Task DeleteAsync(string id);
        Task<List<Answer>> GetAnswerByQuestionIdAsync(string questionId);
        Task<Answer> GetAnswerByIdAsync(string id);
        Task VoteAsync(Answer answer);
        
    }
}
