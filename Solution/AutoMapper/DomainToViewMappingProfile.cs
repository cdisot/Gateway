using AutoMapper;
using Domain.Core.CoreData;
using Solution.Models;


namespace Solution.AutoMapper
{
    public class DomainToViewMappingProfile:Profile
    {

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<GatewayDto, Gateway>();
            Mapper.CreateMap<DeviceDto, Device>();
            Mapper.CreateMap<StatusDto, Status>();

        }
    }
}
