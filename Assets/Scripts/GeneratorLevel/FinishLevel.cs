using deVoid.Utils;
using Events;
using GeneratorLevel.Parts;
using Services;
using UnityEngine;

namespace GeneratorLevel
{
    public class FinishLevel : MonoBehaviour
    {
        [SerializeField] private LayerMask layerPart;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var obj = other.gameObject;
            if (layerPart.CheckLayer(obj.layer))
            {
                obj.GetComponent<APartLevel>().Unvisible();
                Signals.Get<OnGenerateNextLevel>().Dispatch();
            }
        }
    }
}