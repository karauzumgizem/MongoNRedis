using FarmasiCase.Shared.Entities.Abstract;

namespace FarmasiCase.Entities.Dto
{
    public class ProductDto : DtoBase
    {
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string ProductName { get; set; }
    }
}
