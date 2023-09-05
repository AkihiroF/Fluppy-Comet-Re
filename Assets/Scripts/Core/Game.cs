using deVoid.Utils;
using DG.Tweening;
using Events;
using Input;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Core
{
    public class Game
    {
        private PlayerInput _input;
        private InputHandler _inputHandler;
        private bool _isPlay;
        public Game(PlayerInput input, InputHandler inputHandler)
        {
            _input = input;
            _inputHandler = inputHandler;
            Time.timeScale = 0;
            _isPlay = false;
        }

        private void Bind()
        {
            _input.Player.Jump.performed += _inputHandler.InputJump;
            _input.Player.Jump.performed += OnStartGame;
        }

        private void ActivateInput()
        {
            _input.Player.Enable();
        }

        private void OnStartGame(InputAction.CallbackContext obj)
        {
            if(_isPlay)
                return;
            _isPlay = true;
            Time.timeScale = 1;
            Signals.Get<OnStartGame>().Dispatch();
        }

        private void Subscribe()
        {
            Signals.Get<OnDie>().AddListener(Die);
        }

        private void Unsubscribe()
        {
            Signals.Get<OnDie>().RemoveListener(Die);
        }

        private void Die()
        {
            DOTween.KillAll();
            Unsubscribe();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void StartGame()
        {
            Bind();
            ActivateInput();
            Subscribe();
        }
        
        
    }
}