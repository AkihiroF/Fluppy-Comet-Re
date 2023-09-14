using deVoid.Utils;
using DG.Tweening;
using Events;
using Input;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using VContainer;

namespace Core
{
    public class Game
    {
        private readonly PlayerInput _input;
        private readonly InputHandler _inputHandler;
        private bool _isGameStarted;

        [Inject]
        public Game(PlayerInput input, InputHandler inputHandler)
        {
            _input = input;
            _inputHandler = inputHandler;
            InitializeGame();
        }

        private void InitializeGame()
        {
            PauseGame();
            _isGameStarted = false;
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
        }

        private void ResumeGame()
        {
            Time.timeScale = 1;
        }

        private void BindInputActions()
        {
            _input.Player.Jump.performed += _inputHandler.InputJump;
            _input.Player.Jump.performed += StartGameOnFirstJump;
        }

        private void EnableInput()
        {
            _input.Player.Enable();
        }

        private void StartGameOnFirstJump(InputAction.CallbackContext context)
        {
            if (_isGameStarted)
                return;

            _isGameStarted = true;
            ResumeGame();
            Signals.Get<OnStartGame>().Dispatch();
        }

        private void SubscribeToEvents()
        {
            Signals.Get<OnDie>().AddListener(OnPlayerDie);
        }

        private void UnsubscribeFromEvents()
        {
            Signals.Get<OnDie>().RemoveListener(OnPlayerDie);
        }

        private void OnPlayerDie()
        {
            DOTween.KillAll();
            UnsubscribeFromEvents();
            ReloadCurrentScene();
        }

        private void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void StartGame()
        {
            BindInputActions();
            EnableInput();
            SubscribeToEvents();
        }
    }
}
