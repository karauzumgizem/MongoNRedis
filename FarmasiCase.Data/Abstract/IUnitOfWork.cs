using System;

namespace FarmasiCase.Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
       
        IProductRepository ProductRepository { get; }
        IBasketRepository BasketRepository { get; }
        int Save();
    }
}
