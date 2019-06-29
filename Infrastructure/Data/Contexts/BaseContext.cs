using MongoDB.Driver;

namespace Product.api.Infrastructure.Data.Contexts {
    public abstract class BaseContext {
        public IMongoDatabase Database{get;private set;}

        public BaseContext (MongoDBConnection connection, string databaseName) {
            Database = connection.Connection.GetDatabase(databaseName);
        }
    }
}