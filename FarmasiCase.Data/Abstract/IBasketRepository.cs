using FarmasiCase.Entities.Concrete;
using FarmasiCase.Entities.Dto;
using FarmasiCase.Shared.Data.Abstract;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiCase.Data.Abstract
{
    public interface IBasketRepository : IEntityRepository<Basket>
    {
        Task<List<BasketDto>> GetBasket(string key, IDistributedCache cache);
        Task<List<BasketDto>> UpdateBasket(BasketDto model, IDistributedCache cache);
        bool DeleteBasket(BasketDto model, IDistributedCache cache);
    }
}
