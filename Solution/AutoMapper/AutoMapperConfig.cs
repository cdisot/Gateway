

using AutoMapper;

namespace Solution.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewMappingProfile>();
                x.AddProfile<ViewModelToDemainMappingProfile>();
            }
            );



        }
    }
}
