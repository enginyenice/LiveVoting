using Business.Abstract;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Hubs
{
    public class MyHub : Hub
    {
        private readonly IAnswerService _answerService;

        public MyHub(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        public async Task GetVoteProgressBar(string questionId)
        {
            await Clients.Group($"ReceiveQuestion-{questionId}").SendAsync("ReceiveProgressBar", _answerService.GetProgressBar(questionId));
        }
        public async Task AddToGroup(string questionId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"ReceiveQuestion-{questionId}");

        }
    }
}
