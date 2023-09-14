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
        [SerializeField] private PlayerInteractiveComponent interactive;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(uiPreviewer);
            builder.Register<ScoreDataBase>(Lifetime.Transient).AsSelf();
            builder.RegisterInstance(interactive);
        }
    }
}