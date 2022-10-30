using AutoMapper;
using IAM.Application.Interfaces;
using IAM.Application.Models;
using IAM.Persistance.Context;

namespace IAM.Application.Services
{
    public class UserService : IUserService
    {
        private BaseDbContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(BaseDbContext context, IJwtUtils jwtUtils, IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public AuthenticateApplicationResponseModel Authenticate(AuthenticateApplicationRequestModel request)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Register(RegisterApplicationRequestModel request)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, UpdateApplicationRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
