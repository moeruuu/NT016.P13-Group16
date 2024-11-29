using MongoDB.Driver;
using API_Server.Data;
using Microsoft.Extensions.Configuration;
namespace API_Server.Service
{
    public class CoopService
    {
        private readonly IMongoCollection<Room> roomcollection;
        private readonly IConfiguration configuration;
        public CoopService(IConfiguration configuration, IMongoDatabase db)
        {
           this.configuration = configuration;
            roomcollection = db.GetCollection<Room>("Rooms");
        }

        public async Task<string> CreateIDRoom()
        {
            //Kiem tra xem co collection Rooms chua
            var client = new MongoClient(configuration.GetSection("MongoDB:ConnectionString").Value);
            var database = client.GetDatabase("DOAN");
            var collectionname = await database.ListCollectionNamesAsync();
            var collectionlist = await collectionname.ToListAsync(); 
            bool roomexist = collectionlist.Any(name => name == "Rooms");
            string randomid = "";
            while (true)
            {
                randomid = new Random().Next(1, 10000000).ToString("D8");
                //if (roomcollecion.)
                if (roomexist)
                {
                    var filter = Builders<Room>.Filter.Eq(r => r.RoomId, randomid);
                    var find = await roomcollection.Find(filter).FirstOrDefaultAsync();
                    if (find == null)
                    {
                        break;
                    }
                }
                else { break; }
            }
            return randomid;

        }

    }

}
