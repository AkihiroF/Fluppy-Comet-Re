using Input;
using Player;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerMovementComponent movementComponent;
        private void Awake()
        {
            var input = new PlayerInput();
            var inputHandler = new InputHandler(movementComponent);
            var game = new Game(input, inputHandler);
            
            game.StartGame();
        }
    }
}
