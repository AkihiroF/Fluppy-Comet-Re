using GeneratorLevel;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class LvlGeneratorInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<PoolPartsLevel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<PartCollector>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<LvlGenerator>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}