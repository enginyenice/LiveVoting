using Core.Response;
using Dtos.Answer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAnswerService
    {
        Task<Response<NoContent>> CreateAsync(CreateAnswerDto createAnswerDto);

        Task<Response<NoContent>> CreateListAsync(List<CreateAnswerDto> createAnswersDto);

        Task<Response<NoContent>> UpdateAsync(CreateAnswerDto createAnswerDto);

        Task<Response<NoContent>> DeleteAsync(string id);

        Task<Response<NoContent>> VoteAsync(AnswerVoteAddDto answerVoteAddDto);

        Task<Response<List<AnswerVoteDto>>> GetAnswerByQuestionIdAsync(string questionId);

        Task<Response<List<VoteProgressBarDto>>> GetProgressBar(string questionId);
    }
}