using ClayBackendCase.API.Core.Dto;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Core.Interfaces.Auth
{
    public interface IJwtFactory
    {
        Token GenerateToken(string id, string userName, string role);
    }
}
