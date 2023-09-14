using GeneratorLevel;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class LvlGeneratorInstaller : LifetimeScope
    {
        [SerializeField] private LvlGenerator lvlGenerator;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<PoolPartsLevel>(Lifetime.Transient).AsSelf();
            builder.Register<PartCollector>(Lifetime.Transient).AsSelf();
            builder.RegisterInstance<LvlGenerator>(lvlGenerator);
        }
    }
}