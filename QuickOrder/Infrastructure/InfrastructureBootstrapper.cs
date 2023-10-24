using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    internal class InfrastructureBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            var assemblyTypes = typeof(InfrastructureBootstrapper).Assembly.GetNoAbstractTypes();

            services.AddImplementations(ServiceLifetime.Scoped, typeof(IBaseRepository), assemblyTypes);
        }
    }
}
