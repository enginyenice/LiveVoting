using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.Answer
{
    public class AnswerVoteDto
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string Title { get; set; }
        public int Vote { get; set; }
    }
}
