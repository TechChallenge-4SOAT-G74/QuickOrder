using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class RootBootstrapper
    {
        public static void BootstrapperRegisterServices(this IServiceCollection services)
        {
            new ApplicationBootstrapper().ChildServiceRegister(services);
            new InfrastructureBootstrapper().ChildServiceRegister(services);
        }
    }
}
