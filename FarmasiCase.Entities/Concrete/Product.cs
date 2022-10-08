﻿using FarmasiCase.Shared.Entities.Abstract;

namespace FarmasiCase.Entities.Concrete
{
    public class Products : EntityBase, IEntity
    {
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string ProductName { get; set; }
    }
}
