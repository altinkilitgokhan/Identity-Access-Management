using AutoMapper;
using IAM.Application.Models;
using IAM.Domain.Entities;

namespace IAM.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, AuthenticateApplicationResponseModel>();
            CreateMap<RegisterApplicationRequestModel, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }));
            
            /*CreateMap<AuthenticateRequestModel, AuthenticateApplicationRequestModel>();
            CreateMap<RegisterRequestModel, RegisterApplicationRequestModel>();

            CreateMap<UpdateRequestModel, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) => 
                    {
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;
                        
                        return true;
                    }
                 ));*/
        }
    }
}
