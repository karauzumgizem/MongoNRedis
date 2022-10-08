using FarmasiCase.Data.Abstract;
using FarmasiCase.Entities.Concrete;
using FarmasiCase.Entities.Dto;
using FarmasiCase.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace FarmasiCase.Data.Concrete.EntityFramework.Repositories
{
 
    public class EfBasketRepository : EfEntityRepositoryBase<Basket>, IBasketRepository
    {
        public bool DeleteBasket(BasketDto model, IDistributedCache cache)
        {
            var list = new List<BasketDto>();
            string json = "";
            var prodsFromCache =  cache.Get("prod");
            if (prodsFromCache != null)
            {
                json = Encoding.UTF8.GetString(prodsFromCache);
                if (json.Contains('['))
                    list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BasketDto>>(json.ToString());
                else
                {
                    var item = Newtonsoft.Json.JsonConvert.DeserializeObject<BasketDto>(model.ToString());
                    list.Add(new BasketDto { ProductName = item.ProductName, Price = item.Price });
                }

                list.Remove(list.Find(o => o.Id == model.Id));
                json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                prodsFromCache = Encoding.UTF8.GetBytes(json);
                var options = new DistributedCacheEntryOptions()
                   .SetSlidingExpiration(TimeSpan.FromDays(1)) // belirli bir süre erişilmemiş ise expire eder
                   .SetAbsoluteExpiration(DateTime.Now.AddMonths(1)); // belirli bir süre sonra expire eder.
                 cache.SetAsync("prod", prodsFromCache, options);
                return true;
            }
            return false;
        }

        public async Task<List<BasketDto>> GetBasket(string key, IDistributedCache cache)
        {
            try
            {
                List<BasketDto> products = new List<BasketDto>();
                var basket = await cache.GetStringAsync(key);
                if (String.IsNullOrEmpty(basket))
                    return null;
                else
                {
                    if (basket.Contains('['))
                        products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BasketDto>>(basket.ToString());
                    else
                    {
                        var item = Newtonsoft.Json.JsonConvert.DeserializeObject<BasketDto>(basket.ToString());
                        products.Add(new BasketDto { ProductName = item.ProductName, Price = item.Price });
                    }
                    return products;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<List<BasketDto>> UpdateBasket(BasketDto model, IDistributedCache cache)
        {
            string json = "";
            List<BasketDto> products = new List<BasketDto>();
            var prodsFromCache = await cache.GetAsync("prod");
            if (prodsFromCache != null)
            {
                json = Encoding.UTF8.GetString(prodsFromCache);
                try
                {
                    if (json.Contains('['))
                        products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BasketDto>>(json.ToString());
                    else
                        Newtonsoft.Json.JsonConvert.DeserializeObject<BasketDto>(json);

                    products.Add(new BasketDto { ProductName = model.ProductName, Price = model.Price, Id = model.Id });
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(products);
                    prodsFromCache = Encoding.UTF8.GetBytes(json);
                    var options = new DistributedCacheEntryOptions()
                 .SetSlidingExpiration(TimeSpan.FromDays(1))
                 .SetAbsoluteExpiration(DateTime.Now.AddMonths(1));
                    await cache.SetAsync("prod", prodsFromCache, options);
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                prodsFromCache = Encoding.UTF8.GetBytes(json);
                var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1)) // belirli bir süre erişilmemiş ise expire eder
                        .SetAbsoluteExpiration(DateTime.Now.AddMonths(1)); // belirli bir süre sonra expire eder.
                await cache.SetAsync("prod", prodsFromCache, options);

            }
            return await GetBasket("prod", cache);
        }
    }
}

