using Microsoft.Extensions.DependencyInjection;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Infrastructure
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
