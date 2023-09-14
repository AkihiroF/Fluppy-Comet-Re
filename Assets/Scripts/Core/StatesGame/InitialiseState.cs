using deVoid.Utils;
using Events;
using Input;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace Core.StatesGame
{
    public class InitialiseState : IStateGame
    {
        private readonly PlayerInput _input;
        private readonly InputHandler _inputHandler;
        [Inject]
        public InitialiseState(PlayerInput input, InputHandler inputHandler)
        {
            _input = input;
            _inputHandler = inputHandler;
        }
        public void Enter()
        {
            Time.timeScale = 0;
            BindInputActions();
            EnableInput();
        }
        
        private void BindInputActions()
        {
            _input.Player.Jump.performed += _inputHandler.InputJump;
            _input.Player.Jump.performed += StartGameOnFirstJump;
        }

        private void UnBindInputActions()
        {
            _input.Player.Jump.performed -= StartGameOnFirstJump;
        }
        
        private void StartGameOnFirstJump(InputAction.CallbackContext context)
        {
            UnBindInputActions();
            Signals.Get<OnSwitchStateGame>().Dispatch(typeof(RunningState));
        }
        private void EnableInput()
        {
            _input.Player.Enable();
        }
        
    }
}