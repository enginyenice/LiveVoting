using Entities.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Settings
{
    public class MongoSettings : IMongoSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string QuestionCollectionName { get; set; }
        public string AnswerCollectionName { get; set; }
    }
}
