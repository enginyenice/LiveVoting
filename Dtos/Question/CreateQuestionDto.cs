using System.Collections.Generic;

namespace Dtos.Question
{
    public class CreateQuestionDto
    {
        public CreateQuestionDto()
        {
            Answers = new List<string>();
        }

        public string Title { get; set; }
        public List<string> Answers { get; set; }
    }
}