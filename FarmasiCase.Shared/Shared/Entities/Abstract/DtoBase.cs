using System;

namespace FarmasiCase.Shared.Entities.Abstract
{
    public abstract class DtoBase
    {
        public virtual string Id { get; set; }="";
        public virtual bool IsActive { get; set; } = true;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual int CreatedUser { get; set; }
        public virtual string CreatedDate { get; set; } = "";
        public virtual int ModifiedUser { get; set; }
        public virtual string ModifiedDate { get; set; } = "";
    }
}
