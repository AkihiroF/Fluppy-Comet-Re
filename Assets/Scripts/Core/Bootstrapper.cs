using Core.StatesGame;
using deVoid.Utils;
using Events;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class Bootstrapper : MonoBehaviour, IStartable
    {
        private Game _game;

        [Inject]
        private void Construct(Game game)
        {
            _game = game;
        }

        public void Start()
        {
            _game.StartGame();
        }
    }
}
