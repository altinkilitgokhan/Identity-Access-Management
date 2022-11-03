using IAM.Domain.Entities;

namespace IAM.Application.Helpers.JwtHelpers
{
    public interface IJwtUtils
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
    }
}
