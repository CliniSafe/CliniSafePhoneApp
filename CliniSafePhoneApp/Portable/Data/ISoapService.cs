using CliniSafePhoneApp.Portable.Models;
using System.Threading.Tasks;


namespace CliniSafePhoneApp.Portable.Data
{
    public interface ISoapService
    {
        Task<string> HelloWorldAsync();

        Task<string> HandShakeAsync(HandshakeHeader handShakeHeader);

        Task<string> AuthenticateAsync(AuthHeader authHeader);

        Task HelloErrorAsync();

        Task<string> EchoAsync(string inputValue);

        Models.AuthHeader GetAuthHeader();

        Models.HandshakeHeader GetHandshakeHeader();
    }
}
