namespace Product.api.Infrastructure.Data.Connections {
    public class UserDatabase : MongoDBConnection {
        public UserDatabase (string connectionString, bool isSsl) : base (connectionString, isSsl) { }
    }
}