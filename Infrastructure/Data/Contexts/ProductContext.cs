using MongoDB.Driver;
using Product.api.Infrastructure.Data.Connections;

namespace Product.api.Infrastructure.Data.Contexts {
    public class ProductContext : BaseContext {

        protected static string DatabaseName = "product";

        public ProductContext (ProductDatabase connection) : base (connection, DatabaseName) { }

        public IMongoCollection<Domain.Models.Product.Product> Products {
            get {
                return this.Database.GetCollection<Domain.Models.Product.Product> ("Product");
            }
        }

    }
}