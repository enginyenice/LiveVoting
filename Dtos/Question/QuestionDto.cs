using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Dtos.Question
{
    public class QuestionDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Total { get; set; }

    }
}
