using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GeneratorLevel.Parts
{
    public class BasePartLevel : APartLevel
    {
        [SerializeField] private List<GameObject> coins;
        [SerializeField] private List<Transform> obstacles;

        private void OnEnable()
        {
            MoveObstacles();
        }

        private void MoveObstacles()
        {
            foreach (var obstacle in obstacles)
            {
                Vector3 endPos = obstacle.localPosition + new Vector3(0, Random.Range(-3, 3));
                float moveDuration = Random.Range(1, 5);
                obstacle.DOLocalMove(endPos, moveDuration)
                    .SetEase(Ease.InOutSine)
                    .SetLoops(-1, LoopType.Yoyo);
            }
        }

        private void ActivateCoins()
        {
            foreach (var coin in coins)
            {
                coin.SetActive(true);
            }
        }

        private void OnDisable()
        {
            StopObstacleMovement();
            ActivateCoins();
        }

        private void StopObstacleMovement()
        {
            foreach (var obstacle in obstacles)
            {
                obstacle.DOKill();
            }
        }
    }
}