namespace Product.api.Infrastructure.Data.Connections {
    public class ProductDatabase : MongoDBConnection {
        public ProductDatabase (string connectionString, bool isSsl) : base (connectionString, isSsl) { }
    }
}