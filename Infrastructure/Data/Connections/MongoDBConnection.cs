using System;
using System.Security.Authentication;
using MongoDB.Driver;

namespace Product.api.Infrastructure.Data.Connections {
    public class MongoDBConnection {

        public IMongoClient Connection { get; private set; }

        public MongoDBConnection (string connectionString, bool isSsl) {

            try {

                var settings = MongoClientSettings.FromUrl (new MongoUrl (connectionString));

                if (isSsl)
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };

                this.Connection = new MongoClient (settings);

                // var db =this.Connection.ListDatabaseNames().ToList();

            } catch (System.Exception ex) {
                Console.WriteLine (ex.Message);
                Console.WriteLine (ex.StackTrace);
                throw ex;
            }

        }
    }
}