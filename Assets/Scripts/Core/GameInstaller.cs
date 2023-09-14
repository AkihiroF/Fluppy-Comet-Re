using Core.StatesGame;
using GeneratorLevel;
using Input;
using Player;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private PlayerMovementComponent movementComponent;
        [SerializeField] private UIPreviewer uiPreviewer;
        [SerializeField] private PlayerInteractiveComponent interactive;
        [SerializeField] private LvlGenerator lvlGenerator;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance<IMovablePlayer,PlayerMovementComponent>(movementComponent);
            
            builder.RegisterInstance(uiPreviewer);
            builder.Register<ScoreDataBase>(Lifetime.Singleton).AsSelf();
            builder.RegisterInstance(interactive);
            
            builder.Register<PlayerInput>(Lifetime.Singleton).AsSelf();
            builder.Register<InputHandler>(Lifetime.Singleton).AsSelf();

            builder.Register<IStateGame, InitialiseState>(Lifetime.Singleton);
            builder.Register<IStateGame, RunningState>(Lifetime.Singleton);
            builder.Register<IStateGame, DieState>(Lifetime.Singleton);
            
            builder.Register<Game>(Lifetime.Singleton).AsSelf();
            
            builder.Register<PoolPartsLevel>(Lifetime.Singleton).AsSelf();
            builder.Register<PartCollector>(Lifetime.Singleton).AsSelf();
            builder.RegisterInstance(lvlGenerator);
            
            builder.RegisterComponentInHierarchy<Bootstrapper>();
        }
    }
}