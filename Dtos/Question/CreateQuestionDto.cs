using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.Question
{
    public class CreateQuestionDto
    {
        public string Title { get; set; }
        public List<string> Answers { get; set; }
    }
}
