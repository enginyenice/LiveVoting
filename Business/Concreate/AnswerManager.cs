using AutoMapper;
using Business.Abstract;
using Business.Hubs;
using Core.Response;
using DataAccess.Abstract;
using Dtos.Answer;
using Dtos.IpAdress;
using Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class AnswerManager : IAnswerService
    {
        private readonly IAnswerDal _answerDal;
        private readonly IIpAdressService _ipAdressService;
        private readonly IMapper _mapper;
        private readonly IHubContext<MyHub> _hubContext;
        public AnswerManager(IAnswerDal answerDal, IMapper mapper, IHubContext<MyHub> hubContext, IIpAdressService ipAdressService)
        {
            _answerDal = answerDal;
            _mapper = mapper;
            _hubContext = hubContext;
            _ipAdressService = ipAdressService;
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

        public async Task<Response<List<VoteProgressBarDto>>> GetProgressBar(string questionId)
        {
            var answers = await _answerDal.GetAnswerByQuestionIdAsync(questionId);
            int total = answers.Sum(p => p.Vote);
            List<VoteProgressBarDto> voteProgressBarDtos = new List<VoteProgressBarDto>();
            answers.ForEach(x =>
            {
                VoteProgressBarDto voteProgressBarDto = new VoteProgressBarDto();
                voteProgressBarDto.Percent = (total > 0) ? (x.Vote * 100) / total : total;
                voteProgressBarDto.Title = x.Title;
                voteProgressBarDto.Id = x.Id;
                voteProgressBarDto.Vote = x.Vote;
                voteProgressBarDtos.Add(voteProgressBarDto);
            });
            return Response<List<VoteProgressBarDto>>.Success(voteProgressBarDtos);

        }

        public Task<Response<NoContent>> UpdateAsync(CreateAnswerDto createAnswerDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<NoContent>> VoteAsync(AnswerVoteAddDto answerVoteAddDto)
        {
            var answer = await _answerDal.GetAnswerByIdAsync(answerVoteAddDto.Id);
            if (answer == null)
            {
                return Response<NoContent>.Fail("Şık bulunamadı.");
            }
            var result = await _ipAdressService.CheckIfIpAdress(answer.QuestionId,answerVoteAddDto.IpAdress);
            if (!result.IsSuccess)
            {
                return Response<NoContent>.Fail("Bu oylamaya daha önceden katıldınız. Tekrar oy kullanamazsınız");
            }
            IpAdressDto ipAdressDto = new IpAdressDto() { QuestionId = answer.QuestionId, Adress = answerVoteAddDto.IpAdress };
            var ipServiceResult = await _ipAdressService.CreatedAsync(ipAdressDto);
            if (!ipServiceResult.IsSuccess)
            {
                return Response<NoContent>.Fail("Beklenmedik bir hata oluştu");
            }

            await _answerDal.VoteAsync(answer); // 1 oy arttır.
            await _hubContext.Clients.Group($"ReceiveQuestion-{answer.QuestionId}").SendAsync("ReceiveProgressBar", await GetProgressBar(answer.QuestionId));
            return Response<NoContent>.Success();
        }
    }
}
