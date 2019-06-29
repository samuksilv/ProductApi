using MongoDB.Driver;

namespace Product.api.Infrastructure.Data.Contexts {
    public class ProductContext : BaseContext {

        protected static string DatabaseName = "product";

        public ProductContext (MongoDBConnection connection) : base (connection, DatabaseName) { }

        public IMongoCollection<Domain.Models.Product.Product> Products {
            get {
                return this.Database.GetCollection<Domain.Models.Product.Product> ("Product");
            }
        }

    }
}