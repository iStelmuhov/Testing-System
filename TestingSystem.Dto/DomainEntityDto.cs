using System;

namespace TestingSystem.Dto
{
    public abstract class DomainEntityDto<TConcreteDto> : Utils.Value<DomainEntityDto<TConcreteDto>>
    {
        public Guid DomainId { get; private set; }

        public bool Show { get; set; }

        protected DomainEntityDto(Guid domainId, bool show)
        {
            DomainId = domainId;
            Show = show;
        }
    }
}
