using IAM.Application.Models;
using IAM.Domain.Entities;

namespace IAM.Application.Interfaces
{
    public interface IUserService
    {
        AuthenticateApplicationResponseModel Authenticate(AuthenticateApplicationRequestModel request);
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int Id);
        void Register(RegisterApplicationRequestModel request);
        void Update(int Id, UpdateApplicationRequestModel request);
        void Delete(int Id);
    }
}
