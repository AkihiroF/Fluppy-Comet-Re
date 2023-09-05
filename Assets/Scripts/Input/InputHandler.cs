using System;
using Player;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputHandler
    {
        private PlayerMovementComponent _movementComponent;

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