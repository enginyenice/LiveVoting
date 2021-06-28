using Business.Abstract;
using Core.Response;
using Dtos.Question;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionDto createQuestionDto)
        {
            return Ok(await _questionService.CreateAsync(createQuestionDto));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(string id)
        {
            return Ok(await _questionService.GetQuestionByIdAsync(id));

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _questionService.GetAllAsync());

        }
    }
}
