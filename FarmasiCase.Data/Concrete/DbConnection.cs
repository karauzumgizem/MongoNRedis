using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiCase.Data.Concrete
{
    public class DbConnection
    {
        private static MongoClient _client;
        private static MongoServer _server;
        private static MongoDatabase _database;
        private static DbConnection Instance;
        private DbConnection() { }
        public static DbConnection ActiveInstance
        {
            get
            {
                if (Instance == null)
                {
                    _client = new MongoClient("mongodb://localhost:27017");
                    _server = _client.GetServer();
                    _database = _server.GetDatabase("FarmasiCase");
                    Instance = new DbConnection();
                }
                return Instance;
            }
        }
        public MongoDatabase Db
        {
            get
            {
                return _database;
            }
        }
    }
}
