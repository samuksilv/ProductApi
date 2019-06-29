using System;
using System.Security.Authentication;
using MongoDB.Driver;

namespace Product.api.Infrastructure.Data {
    public class MongoDBConnection {
        public string ConnectionString { get; private set; }
        public bool IsSsl { get; private set; }
        public IMongoClient Connection { get; private set; }

        public MongoDBConnection (string connectionString, bool isSsl) {

            try {
                this.ConnectionString = connectionString;
                this.IsSsl = isSsl;

                // var settings = MongoClientSettings.FromConnectionString (this.ConnectionString);
                var settings = MongoClientSettings.FromUrl (new MongoUrl(this.ConnectionString));
                if (this.IsSsl)
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };

                this.Connection = new MongoClient (settings);

            } catch (System.Exception ex) {
                Console.WriteLine (ex.Message);
                Console.WriteLine (ex.StackTrace);
            }

        }
    }
}