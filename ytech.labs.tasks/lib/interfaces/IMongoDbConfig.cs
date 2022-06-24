namespace ytech.labs.tasks.lib.interfaces
{
    public interface IMongoDbConfig
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
    }
}