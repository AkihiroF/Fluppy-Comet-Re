using deVoid.Utils;
using Events;
using GeneratorLevel.Parts;
using UnityEngine;
using VContainer;

namespace GeneratorLevel
{
    public class LvlGenerator : MonoBehaviour
    {
        [SerializeField] private APartLevel partLvl;
        [SerializeField] private int lenghtGeneratingLvl;
        
        private PoolPartsLevel _pool;
        private Vector2 _positionSpawn;
        private APartLevel _lastPart;

        private void Start()
        {
            GenerateStartLocation();
            Signals.Get<OnGenerateNextLevel>().AddListener(GenerateParts);
        }

        [Inject]
        private void InitializePool(PoolPartsLevel poolPartsLevel)
        {
            _pool = poolPartsLevel;
            _pool.AddToPool(partLvl);
        }

        private void GenerateStartLocation()
        {
            _lastPart = partLvl;
            GenerateParts();
        }

        private void GenerateParts()
        {
            for (int i = 0; i < lenghtGeneratingLvl; i++)
            {
                APartLevel part = GetAndPlacePart();
                _lastPart = part;
            }
        }

        private APartLevel GetAndPlacePart()
        {
            APartLevel part = _pool.GetPartLevel();
            _positionSpawn = CalculateNewPosition(_lastPart, part);
            part.transform.position = _positionSpawn;
            part.gameObject.SetActive(true);
            return part;
        }

        private Vector2 CalculateNewPosition(APartLevel lastPart, APartLevel newPart)
        {
            return (Vector2)lastPart.transform.position + lastPart.GetDistance / 2 + newPart.GetDistance / 2;
        }

        private void OnDestroy()
        {
            Signals.Get<OnGenerateNextLevel>().RemoveListener(GenerateParts);
        }
    }
}
