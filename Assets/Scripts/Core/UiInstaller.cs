using Player;
using UI;
using UnityEngine;
using Zenject;

namespace Core
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private UIPreviewer uiPreviewer;
        public override void InstallBindings()
        {
            Container.Bind<UIPreviewer>().FromInstance(uiPreviewer);
            Container.Bind<ScoreDataBase>().AsSingle().NonLazy();
            Container.Bind<PlayerInteractiveComponent>().AsSingle();
        }
    }
}