using AutoMapper;
using Domain.Core.CoreData;
using Solution.Models;
namespace Solution.AutoMapper
{
    public class ViewModelToDemainMappingProfile: Profile
    {

        public override string ProfileName
        {
            get { return "DomainToViewMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Gateway, GatewayDto>();
            Mapper.CreateMap<Device, DeviceDto>();
            Mapper.CreateMap<Status, StatusDto>();

           

        }
    }
}
