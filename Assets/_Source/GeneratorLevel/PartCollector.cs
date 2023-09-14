using _Source.Events;
using _Source.GeneratorLevel.Parts;
using _Source.Services;
using UnityEngine;
using VContainer;

namespace _Source.GeneratorLevel
{
    public class PartCollector : MonoBehaviour
    {
        [SerializeField] private LayerMask layerPart;
        [Inject] private PoolPartsLevel _pool;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var obj = other.gameObject;
            if (layerPart.CheckLayer(obj.layer))
            {
                var partLvl = obj.GetComponent<APartLevel>();
                _pool.AddToPool(partLvl);
                obj.SetActive(false);
                Signals.Get<OnGenerateNextLevel>().Dispatch();
            }
        }
    }
}