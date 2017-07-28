using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Utils
{
    public class Entity
    {
        public Guid Id { get; private set; }

        public long DatabaseId { get; set; }
        public bool IsHided { get;  private set; }

        protected Entity() { }

        protected Entity(Guid domainId)
        {
            this.Id = domainId;
            IsHided = false;
        }

        public void Hide()
        {
            IsHided = true;
        }

        public void UnHide()
        {
            IsHided = false;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            var otherEntity = (Entity)obj;
            return Id == otherEntity.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
