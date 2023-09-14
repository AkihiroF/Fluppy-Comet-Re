using System;
using Player;
using UnityEngine.InputSystem;
using VContainer;

namespace Input
{
    public class InputHandler
    {
        private PlayerMovementComponent _movementComponent;

        [Inject]
        public InputHandler(PlayerMovementComponent movementComponent)
        {
            _movementComponent = movementComponent;
        }


        public void InputJump(InputAction.CallbackContext obj)
        {
            var isPressed = Math.Abs(obj.ReadValue<float>() - 1) < 1;
            _movementComponent.OnJump(isPressed);
        }
    }
}