using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.Answer
{
    public class VoteProgressBarDto
    {
        public string Id { get; set; }
        public decimal Percent { get; set; } = 0;
        public string Title { get; set; }
    }
}
