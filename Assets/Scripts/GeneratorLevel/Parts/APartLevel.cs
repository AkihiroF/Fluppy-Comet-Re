using UnityEngine;

namespace GeneratorLevel.Parts
{
    public abstract class APartLevel : MonoBehaviour
    {
        [SerializeField] protected Vector2 SizePart;
        [SerializeField] private GameObject prefabPart;
        private float _speed;
        private bool _isDead;
        
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
        
    }
}