using Business.Abstract;
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
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerService _answersService;

        public AnswersController(IAnswerService answersService)
        {
            _answersService = answersService;
        }
        [HttpGet("GetAnswersByQuestionId/{questionId}")]
        public async Task<IActionResult> GetAnswersByQuestionId(string questionId)
        {
            return Ok(await _answersService.GetAnswerByQuestionIdAsync(questionId));

        }

        [HttpGet("GetProgressBar/{questionId}")]
        public async Task<IActionResult> GetProgressBar(string questionId)
        {
            return Ok(await _answersService.GetProgressBar(questionId));

        }

        [HttpPost]
        public async Task<IActionResult> Vote(string id)
        {
            return Ok(await _answersService.VoteAsync(id));

        }
    }
}
