using Business.Abstract;
using Dtos.Answer;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("vote")]
        public async Task<IActionResult> Vote(AnswerVoteAddDto answerVoteAddDto)
        {
            return Ok(await _answersService.VoteAsync(answerVoteAddDto));
        }
    }
}