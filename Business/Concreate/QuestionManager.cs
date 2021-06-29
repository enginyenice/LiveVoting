using AutoMapper;
using Business.Abstract;
using Core.Response;
using DataAccess.Abstract;
using Dtos.Answer;
using Dtos.Question;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _questionDal;
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;

        public QuestionManager(IQuestionDal questionDal, IMapper mapper, IAnswerService answerService)
        {
            _questionDal = questionDal;
            _mapper = mapper;
            _answerService = answerService;
        }

        public async Task<Response<QuestionDto>> CreateAsync(CreateQuestionDto createQuestionDto)
        {
            if (string.IsNullOrEmpty(createQuestionDto.Title))
            {
                return Response<QuestionDto>.Fail("Soru boş olamaz");
            }
            if (createQuestionDto.Title.Length < 10)
            {
                return Response<QuestionDto>.Fail("Soru çok kısa en az 10 karakterden oluşmalıdır");
            }
            if (createQuestionDto.Answers.Count < 2)
            {
                return Response<QuestionDto>.Fail("En az 2 şık girilmelidir");
            }


            Question question = _mapper.Map<Question>(createQuestionDto);
            await _questionDal.CreateAsync(question);

            List<CreateAnswerDto> createAnswerDtos = new List<CreateAnswerDto>();
            foreach (var answer in createQuestionDto.Answers)
            {
                createAnswerDtos.Add(new CreateAnswerDto
                {
                    QuestionId = question.Id,
                    Title = answer
                });
            }
            await _answerService.CreateListAsync(createAnswerDtos);

            
            return Response<QuestionDto>.Success(_mapper.Map<QuestionDto>(question));
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var question = await _questionDal.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return Response<NoContent>.Fail("Soru bulunamadı.");
            }
            await _questionDal.DeleteAsync(question.Id);
            return Response<NoContent>.Success();
        }

        public async Task<Response<List<QuestionDto>>> GetAllAsync()
        {
            var questions = await _questionDal.GetAllAsync();

            var questionsDto = _mapper.Map<List<QuestionDto>>(questions);
            foreach (var item in questionsDto)
            {
                var answers =await _answerService.GetAnswerByQuestionIdAsync(item.Id);
                item.Total= answers.Data.Sum(p => p.Vote);
            }

            questionsDto = questionsDto.OrderByDescending(p => p.Total).Take(10).ToList();

            return Response<List<QuestionDto>>.Success(questionsDto);
        }

        public async Task<Response<QuestionDto>> GetQuestionByIdAsync(string id)
        {
            var question = await _questionDal.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return Response<QuestionDto>.Fail("Soru bulunamadı.");
            }
            var questionDto = _mapper.Map<QuestionDto>(question);
            return Response<QuestionDto>.Success(questionDto);
        }

        public Task<Response<NoContent>> UpdateAsync(CreateQuestionDto createQuestionDto)
        {
            throw new NotImplementedException();
        }
    }
}
