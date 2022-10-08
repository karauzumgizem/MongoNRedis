using FarmasiCase.Shared.Entities.Abstract;

namespace FarmasiCase.Entities.Dto
{
    public class BasketDto : DtoBase
    {
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string  Quantity { get; set; }
   
    }
}
