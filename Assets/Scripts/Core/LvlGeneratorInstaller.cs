using GeneratorLevel;
using Zenject;

namespace Core
{
    public class LvlGeneratorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PoolPartsLevel>().AsSingle().NonLazy();
            Container.Bind<PartCollector>().AsSingle();
            Container.Bind<LvlGenerator>().AsSingle();
        }
    }
}