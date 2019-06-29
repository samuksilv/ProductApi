using MongoDB.Driver;
using Product.api.Domain.Models.User;
using Product.api.Infrastructure.Data.Connections;

namespace Product.api.Infrastructure.Data.Contexts {
    public class UserContext : BaseContext {

        protected static string DatabaseName = "user";

        public UserContext (UserDatabase connection) : base (connection, DatabaseName) { }

        public IMongoCollection<Client> Clients {
            get {
                return this.Database.GetCollection<Client> ("client");
            }
        }
    }
}