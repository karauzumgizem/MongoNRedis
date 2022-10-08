using System;

namespace FarmasiCase.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        public virtual string Id { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual int CreatedUser { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual int ModifiedUser { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
    }
}
