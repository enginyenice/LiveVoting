using AutoMapper;
using Business.Abstract;
using Core.Response;
using DataAccess.Abstract;
using Dtos.Answer;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class AnswerManager : IAnswerService
    {
        private readonly IAnswerDal _answerDal;
        private readonly IMapper _mapper;

        public AnswerManager(IAnswerDal answerDal, IMapper mapper)
        {
            _answerDal = answerDal;
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> CreateAsync(CreateAnswerDto createAnswerDto)
        {
            var answer = _mapper.Map<Answer>(createAnswerDto);

            await _answerDal.CreateAsync(answer);
            return Response<NoContent>.Success();
        }

        public async Task<Response<NoContent>> CreateListAsync(List<CreateAnswerDto> createAnswersDto)
        {
            var answers = _mapper.Map<List<Answer>>(createAnswersDto);
            await _answerDal.CreateListAsync(answers);
            return Response<NoContent>.Success();
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var answer = await _answerDal.GetAnswerByIdAsync(id);
            if (answer == null)
            {
                return Response<NoContent>.Fail("Şık bulunamadı.");
            }
            await _answerDal.DeleteAsync(answer.Id);
            return Response<NoContent>.Success();
        }

        public async Task<Response<List<AnswerVoteDto>>> GetAnswerByQuestionIdAsync(string questionId)
        {
            var answers = await _answerDal.GetAnswerByQuestionIdAsync(questionId);
            var answerVoteDtos = _mapper.Map<List<AnswerVoteDto>>(answers);
            return Response<List<AnswerVoteDto>>.Success(answerVoteDtos);
        }

        public Task<Response<NoContent>> UpdateAsync(CreateAnswerDto createAnswerDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<NoContent>> VoteAsync(string id)
        {
            var answer =await _answerDal.GetAnswerByIdAsync(id);
            if(answer == null)
            {
                return Response<NoContent>.Fail("Şık bulunamadı.");
            }
            await _answerDal.VoteAsync(answer); // 1 oy arttır.
            return Response<NoContent>.Success();
        }
    }
}
