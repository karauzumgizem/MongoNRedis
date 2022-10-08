using FarmasiCase.Data.Abstract;
using FarmasiCase.Data.Concrete.EntityFramework.Repositories;
using FarmasiCase.Shared.Data.Abstract;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Data.SqlClient;

namespace FarmasiCase.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EfProductRepository _productRepository;
        private readonly EfBasketRepository _basketRepository;
        public IProductRepository ProductRepository => _productRepository ?? new EfProductRepository();
        public IBasketRepository BasketRepository => _basketRepository ?? new EfBasketRepository();


        public int Save()
        {
            try
            {
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Veritabanı işlemlerinde bir hata oluştu. " + ex.Message);
            }
        }
        public void Dispose()
        {
            
            GC.SuppressFinalize(this);
        }
    }
}
