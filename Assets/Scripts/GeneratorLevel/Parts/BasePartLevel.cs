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
            foreach (var obstacle in obstacles)
            {
                var endPos = obstacle.position + new Vector3(0, Random.Range(-3, 3));
                var moveDuration = Random.Range(1, 5);
                obstacle.DOLocalMove(endPos, moveDuration)
                    .SetEase(Ease.InOutSine) // Тип сглаживания
                    .SetLoops(-1, LoopType.Yoyo);
            }
        }

        public override void Unvisible()
        {
            foreach (var coin in coins)
            {
                coin.SetActive(true);
            }
            ReturnToPool();
        }

        protected override void ReturnToPool()
        {
            _poolParts.AddToPool(typeof(BasePartLevel), this);
        }

        private void OnDisable()
        {
            foreach (var obstacle in obstacles)
            {
                obstacle.DOComplete();
            }
        }
    }
}