using AutoMapper;
using FarmasiCase.Data.Abstract;
using FarmasiCase.Entities.Concrete;
using FarmasiCase.Entities.Dto;
using FarmasiCase.Services.Abstract;
using FarmasiCase.Shared.Data.Paging;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiCase.Services.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly IDistributedCache _redisCache;
        private readonly IUnitOfWork _unitOfWork;
        public BasketService(IDistributedCache cache, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _redisCache = cache;
        }
        public async Task<List<BasketDto>> GetBasket(string key)
        {
            var data = _unitOfWork.BasketRepository.GetBasket(key, _redisCache);
            if (data != null)
            {
                return await data;
            }
            return null;
        }

        public async Task<List<BasketDto>> UpdateBasket(BasketDto basket)
        {
            var data = _unitOfWork.BasketRepository.UpdateBasket(basket, _redisCache);
            if (data != null)
            {
                return await data;
            }
            return null;
        }


        public  bool DeleteBasket(BasketDto basket)
        {
            var data = _unitOfWork.BasketRepository.DeleteBasket(basket, _redisCache);
            return data;
        }
    }
}


