using FarmasiCase.Entities.Concrete;
using FarmasiCase.Entities.Dto;
using FarmasiCase.Shared.Service.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmasiCase.Services.Abstract
{
    public interface IBasketService
    {
        Task<List<BasketDto>> UpdateBasket(BasketDto basket);
        Task<List<BasketDto>> GetBasket(string key);
        bool DeleteBasket(BasketDto basket);
    }
}
