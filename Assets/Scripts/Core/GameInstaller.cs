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
            // Здесь мы регистрируем компоненты и их зависимости

            // FromInstance аналогичен Zenject
            builder.RegisterInstance(movementComponent);

            // AsSingle().NonLazy() в Zenject аналогично Singleton в VContainer
            builder.Register<PlayerInput>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<InputHandler>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<Game>(Lifetime.Singleton).AsImplementedInterfaces();

            // AsSingle() без NonLazy
            builder.RegisterComponentInHierarchy<Bootstrapper>();
        }
    }
}