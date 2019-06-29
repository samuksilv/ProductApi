using MongoDB.Driver;
using Product.api.Infrastructure.Data.Connections;

namespace Product.api.Infrastructure.Data.Contexts {
    public abstract class BaseContext {
        protected IMongoDatabase Database{get;private set;}

        public BaseContext (MongoDBConnection connection, string databaseName) {
            Database = connection.Connection.GetDatabase(databaseName);
        }
    }
}