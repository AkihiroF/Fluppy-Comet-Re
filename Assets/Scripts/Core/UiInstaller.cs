using Player;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class UiInstaller : LifetimeScope
    {
        [SerializeField] private UIPreviewer uiPreviewer;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(uiPreviewer);
            builder.Register<ScoreDataBase>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<PlayerInteractiveComponent>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}