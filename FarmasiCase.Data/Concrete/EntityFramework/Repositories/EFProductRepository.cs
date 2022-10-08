using FarmasiCase.Data.Abstract;
using FarmasiCase.Entities.Concrete;
using FarmasiCase.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace FarmasiCase.Data.Concrete.EntityFramework.Repositories
{
    public class EfProductRepository : EfEntityRepositoryBase<Products>, IProductRepository
    {
        public List<Products> GetAllMongo()
        {
            List<Products> products = new List<Products>();
            MongoClient client = new MongoClient();

            MongoServer server = client.GetServer();

            MongoDatabase db = server.GetDatabase("FarmasiCase");

            var prods = db.GetCollection("Products");

            var liste = prods.FindAll();
            foreach (var prd in liste)
            {
                products.Add(new Products { ProductName = prd["ProductName"].ToString(), Price = prd["Price"].ToString(), Quantity = prd["Quantity"].ToString(), Id= prd["_id"].ToString() });
            }
            return products;


        }
    }
}

