using AutoMapper;
using RequerimientosST.BL.Models;

namespace RequerimientosST.BL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Applicative, ApplicativeDTO>();
                cfg.CreateMap<ApplicativeDTO, Applicative>();

                cfg.CreateMap<Area, AreaDTO>();
                cfg.CreateMap<AreaDTO, Area>();

                cfg.CreateMap<DevelopmentEngineer, DevelopmentEngineerDTO>();
                cfg.CreateMap<DevelopmentEngineerDTO, DevelopmentEngineer>();

                cfg.CreateMap<Priority, PriorityDTO>();
                cfg.CreateMap<PriorityDTO, Priority>();

                cfg.CreateMap<Requirement, RequirementDTO>();
                cfg.CreateMap<RequirementDTO, Requirement>();
            });
        }
    }
}
