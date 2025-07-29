using System.Security.Claims;

public interface IJwtService
{
    string GenerateToken(int userId, int roleId);
    ClaimsPrincipal? ValidateToken(string token);
}
