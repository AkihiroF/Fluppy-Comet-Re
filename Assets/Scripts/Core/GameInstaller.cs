using Input;
using Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private PlayerMovementComponent movementComponent;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(movementComponent);
            
            builder.Register<PlayerInput>(Lifetime.Transient).AsSelf();
            builder.Register<InputHandler>(Lifetime.Transient).AsSelf();
            builder.Register<Game>(Lifetime.Transient).AsSelf();
            
            builder.RegisterComponentInHierarchy<Bootstrapper>();
        }

        protected override void OnDestroy()
        {
            
        }
    }
}