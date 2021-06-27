using AutoMapper;
using Business.Abstract;
using Core.Response;
using DataAccess.Abstract;
using Dtos.Question;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _questionDal;
        private readonly IMapper _mapper;

        public QuestionManager(IQuestionDal questionDal, IMapper mapper)
        {
            _questionDal = questionDal;
            _mapper = mapper;
        }

        public Task<Response<NoContent>> CreateAsync(CreateQuestionDto createQuestionDto)
        {
            
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<QuestionDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<QuestionDto>> GetQuestionByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> UpdateAsync(CreateQuestionDto createQuestionDto)
        {
            throw new NotImplementedException();
        }
    }
}
