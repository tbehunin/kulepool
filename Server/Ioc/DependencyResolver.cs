using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Dal;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Ioc
{
    public class DependencyResolver
    {
        public static IAppContainer GetAppContainer(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<DefaultModule>();
            builder.Populate(services);

            return new AppContainer(builder.Build());
        }

        public static IServiceProvider GetServiceProvider(IAppContainer appContainer)
        {
            var concrete = appContainer as AppContainer;
            if (concrete == null)
            {
                throw new ArgumentException($"Invalid container type", "appContainer");
            }
            return new AutofacServiceProvider(concrete.Container);
        }
    }
}
