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
            Debug.Log("Const");
            _game = game;
        }
        // private void Awake()
        // {
        //     _game.StartGame();
        // }

        public void Start()
        {
            UnityEngine.Debug.Log("Start");
        }
    }
}
