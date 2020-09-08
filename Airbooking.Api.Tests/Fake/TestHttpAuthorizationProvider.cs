using Airbooking.Api.Providers;

namespace Airbooking.Api.Tests.Fake
{
    public class TestHttpAuthorizationProvider : IHttpAuthorizationProvider
    {
        public string UserId { get; } = "Fakeid";
        public string CurrentEmail { get; } = "fake@fake.com";
    }
}
