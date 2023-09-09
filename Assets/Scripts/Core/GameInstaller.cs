using Input;
using Player;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMovementComponent movementComponent;
        public override void InstallBindings()
        {
            Container.Bind<PlayerMovementComponent>().FromInstance(movementComponent);
            Container.Bind<PlayerInput>().AsSingle().NonLazy();
            Container.Bind<InputHandler>().AsSingle().NonLazy();
            Container.Bind<Game>().AsSingle().NonLazy();
            Container.Bind<Bootstrapper>().AsSingle();
        }
    }
}