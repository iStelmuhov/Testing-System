using System;

namespace TestingSystem.Dto
{
    public abstract class DomainEntityDto<TConcreteDto> : Utils.Value<DomainEntityDto<TConcreteDto>>
    {
        public Guid DomainId { get; private set; }

        protected DomainEntityDto(Guid domainId)
        {
            this.DomainId = domainId;
        }

    }
}
