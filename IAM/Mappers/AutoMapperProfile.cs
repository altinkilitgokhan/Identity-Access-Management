using AutoMapper;
using IAM.Api.Models;
using IAM.Application.Models;
using IAM.Domain.Entities;

namespace IAM.Api.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, AuthenticateResponseModel>();
            CreateMap<RegisterRequestModel, User>();
            CreateMap<AuthenticateRequestModel, AuthenticateApplicationRequestModel>();

            CreateMap<UpdateRequestModel, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) => 
                    {
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;
                        
                        return true;
                    }
                 ));
        }
    }
}
