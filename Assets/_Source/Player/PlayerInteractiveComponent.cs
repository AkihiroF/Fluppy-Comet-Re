using _Source.Core.StatesGame;
using _Source.Events;
using _Source.Services;
using UnityEngine;
using VContainer;

namespace _Source.Player
{
    public class PlayerInteractiveComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask coinLayer;
        [SerializeField] private LayerMask deathLayer;

        private ScoreDataBase _scoreDataBase;

        [Inject]
        private void Construct(ScoreDataBase scoreDataBase)
        {
            _scoreDataBase = scoreDataBase;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            HandleCoinCollision(other);
            HandleDeathCollision(other);
        }

        private void HandleCoinCollision(Collider2D other)
        {
            if (IsCoinLayer(other.gameObject.layer))
            {
                CollectCoin(other.gameObject);
            }
        }

        private void HandleDeathCollision(Collider2D other)
        {
            if (IsDeathLayer(other.gameObject.layer))
            {
                TriggerDeath();
            }
        }

        private bool IsCoinLayer(int layer)
        {
            return coinLayer.CheckLayer(layer);
        }

        private bool IsDeathLayer(int layer)
        {
            return deathLayer.CheckLayer(layer);
        }

        private void CollectCoin(GameObject coin)
        {
            _scoreDataBase.AddCoin();
            coin.SetActive(false);
        }

        private void TriggerDeath()
        {
            Signals.Get<OnSwitchStateGame>().Dispatch(typeof(DieState));
        }
    }
}