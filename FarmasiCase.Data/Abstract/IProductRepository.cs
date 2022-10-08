using FarmasiCase.Entities.Concrete;
using FarmasiCase.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiCase.Data.Abstract
{
    public interface IProductRepository : IEntityRepository<Products>
    {
        List<Products> GetAllMongo();
    }
}
