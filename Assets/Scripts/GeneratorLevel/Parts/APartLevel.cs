using _Source.GenerationLevel;
using deVoid.Utils;
using DG.Tweening;
using Events;
using UnityEngine;

namespace GeneratorLevel.Parts
{
    public abstract class APartLevel : MonoBehaviour
    {
        [SerializeField] protected Vector2 SizePart;
        [SerializeField] private GameObject prefabPart;
        private float _speed;
        private bool _isDead;
        protected PoolPartsLevel _poolParts;
        
        public Vector2 GetDistance
        {
            get
            {
                return SizePart;
            }
        }
        public GameObject GetObject
        {
            get
            {
                return prefabPart;
            }
        }

        public void SetParameters(PoolPartsLevel pool)
        {
            _poolParts = pool;
        }
        public abstract void Unvisible();

        protected abstract void ReturnToPool();
        
    }
}