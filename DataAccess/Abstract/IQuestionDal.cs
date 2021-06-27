﻿using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IQuestionDal
    {
        Task CreateAsync(Question question);
        Task UpdateAsync(Question question);
        Task DeleteAsync(string id);
        Task<List<Question>> GetAllAsync();
        Task<Question> GetQuestionById(string id);

    }
}
