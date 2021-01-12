using GestContact.API.Models.Global.Entities;

namespace GestContact.API.Infrastructure.Security
{
    public interface ITokenService
    {
        string GenerateToken(Customer user);
        Customer ValidateToken(string token);
    }
}