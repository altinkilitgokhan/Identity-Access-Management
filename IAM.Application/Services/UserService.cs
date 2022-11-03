using AutoMapper;
using IAM.Application.Interfaces;
using IAM.Application.Models;
using IAM.Persistance.Context;
using BCrypt.Net;
using IAM.Application.Helpers;
using IAM.Application.Helpers.JwtHelpers;
using IAM.Domain.Entities;

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
            var user = _context.Users.SingleOrDefault(x => x.Username == request.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new AppException("Username or Password is incorrect");

            var response = _mapper.Map<AuthenticateApplicationResponseModel>(user);
            response.Token = _jwtUtils.GenerateToken(user);
            return response;
        }

        public void Delete(int Id)
        {
            var user = GetById(Id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int Id)
        {
            var user = _context.Users.Find(Id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public void Register(RegisterApplicationRequestModel request)
        {
            if (_context.Users.Any(x => x.Username == request.Username))
                throw new AppException("Username '" + request.Username + "' is already taken");
            /*var user = new User
            {
                Username = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName, 
                Email = "gokhan",
                
            };*/
            var user = _mapper.Map<User>(request);

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(int Id, UpdateApplicationRequestModel request)
        {
            var user = GetById(Id);

            if (request.Username != user.Username && _context.Users.Any(x => x.Username == request.Username))
                throw new AppException("Username '" + request.Username + "' is already taken");

            if (!string.IsNullOrEmpty(request.Password))
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            _mapper.Map(request, user);
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
