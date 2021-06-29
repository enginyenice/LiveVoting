using AutoMapper;
using Dtos.Answer;
using Dtos.IpAdress;
using Dtos.Question;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Question, CreateQuestionDto>().ReverseMap();

            CreateMap<Answer, CreateAnswerDto>().ReverseMap();
            CreateMap<Answer, AnswerVoteDto>().ReverseMap();
          
            CreateMap<IpAdress, IpAdressDto>().ReverseMap();
        }
    }
}
