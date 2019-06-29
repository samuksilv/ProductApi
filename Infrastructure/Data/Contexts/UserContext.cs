using MongoDB.Driver;
using Product.api.Domain.Models.User;

namespace Product.api.Infrastructure.Data.Contexts {
    public class UserContext : BaseContext {

        protected static string DatabaseName = "User";

        public UserContext (MongoDBConnection connection) : base (connection, DatabaseName) { }

        public IMongoCollection<Client> Clients {
            get {
                return this.Database.GetCollection<Client> ("Client");
            }
        }
    }
}