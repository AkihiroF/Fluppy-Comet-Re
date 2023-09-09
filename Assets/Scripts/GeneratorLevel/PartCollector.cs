using deVoid.Utils;
using Events;
using GeneratorLevel.Parts;
using Services;
using UnityEngine;
using Zenject;

namespace GeneratorLevel
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