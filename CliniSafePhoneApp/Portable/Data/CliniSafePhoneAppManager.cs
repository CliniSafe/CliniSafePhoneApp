using CliniSafePhoneApp.Portable.Models;
using System.Threading.Tasks;

namespace CliniSafePhoneApp.Portable.Data
{
    public class CliniSafePhoneAppManager
    {
        ISoapService soapService;

        public CliniSafePhoneAppManager(ISoapService service)
        {
            soapService = service;
        }

        public Task<string> HelloWorldAsync()
        {
            return soapService.HelloWorldAsync();
        }

        public Task<string> HandShakeAysnc(HandshakeHeader handShakeHeader)
        {
            return soapService.HandShakeAsync(handShakeHeader);
        }

        public Task<string> AuthenticationAsync(AuthHeader authHeader)
        {
            return soapService.AuthenticateAsync(authHeader);
        }
    }
}
