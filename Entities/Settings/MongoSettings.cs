namespace Entities.Settings
{
    public class MongoSettings : IMongoSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string QuestionCollectionName { get; set; }
        public string AnswerCollectionName { get; set; }
        public string IpAdressCollectionName { get; set; }
    }
}