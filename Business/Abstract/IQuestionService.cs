using Core.Response;
using Dtos.Question;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IQuestionService
    {
        Task<Response<QuestionDto>> CreateAsync(CreateQuestionDto createQuestionDto);
        Task<Response<NoContent>> UpdateAsync(CreateQuestionDto createQuestionDto);
        Task<Response<NoContent>> DeleteAsync(string id);
        Task<Response<QuestionDto>> GetQuestionByIdAsync(string id);
        Task<Response<List<QuestionDto>>> GetAllAsync();

    }
}
