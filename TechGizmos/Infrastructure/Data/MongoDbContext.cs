using MongoDB.Driver;

public class MongoDBContext
{
    private readonly IMongoDatabase _database;

    public MongoDBContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["MongoDBSettings:ConnectionString"]);
        _database = client.GetDatabase(configuration["MongoDBSettings:DatabaseName"]);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}
