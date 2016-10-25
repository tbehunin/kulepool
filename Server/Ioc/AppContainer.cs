using Autofac;

namespace Ioc
{
    public interface IAppContainer
    {
        void Dispose();
    }

    public class AppContainer : IAppContainer
    {

        public AppContainer(IContainer container)
        {
            Container = container;
        }
        public IContainer Container { get; private set; }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}
