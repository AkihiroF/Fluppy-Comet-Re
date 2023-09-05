using System.Collections.Generic;
using _Source.GenerationLevel;
using deVoid.Utils;
using Events;
using GeneratorLevel.Parts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GeneratorLevel
{
    public class GeneratorLvl : MonoBehaviour
    {
        [SerializeField] private List<APartLevel> partsLvl;
        [SerializeField] private int startLenght;
        [SerializeField] private int countAdditionalParts;

        private int _currentLenghtLevel;
        private PoolPartsLevel _pool;
        private Vector2 _positionSpawn;
        private APartLevel _lastPart;

        private void Start()
        {
            _pool = new PoolPartsLevel(partsLvl.Count);
            foreach (var part in partsLvl)
            {
                _pool.AddToPool(typeof(BasePartLevel), part);
            }
            GenerateStartLocation();
            Signals.Get<OnGenerateNextLevel>().AddListener(GenerateNewLevel);
        }

        private void GenerateStartLocation()
        {
            for (int i = 0; i < startLenght; i++)
            {
                
                var part = _pool.GetPartLevel(typeof(BasePartLevel));
                part.transform.position = _positionSpawn;
                _positionSpawn += part.GetDistance;
            }
            var checkPart = _pool.GetPartLevel(typeof(BasePartLevel));
            checkPart.transform.position = _positionSpawn;
            _lastPart = checkPart;
            GenerateEmptyParts();
            _currentLenghtLevel = startLenght + 1;
            IncreaseRandomly();
        }

        private void GenerateNewLevel()
        {
            for (int i = 0; i < _currentLenghtLevel; i++)
            {
                var part = _pool.GetPartLevel(typeof(BasePartLevel));
                _positionSpawn = (Vector2)_lastPart.transform.position + _lastPart.GetDistance/2 + part.GetDistance/2;
                part.transform.position = _positionSpawn;
                _lastPart = part;
            }
            var checkPart = _pool.GetPartLevel(typeof(BasePartLevel));
            _positionSpawn = (Vector2)_lastPart.transform.position + _lastPart.GetDistance/2 + checkPart.GetDistance/2;
            checkPart.transform.position = _positionSpawn;
            _lastPart = checkPart;
            GenerateEmptyParts();
            IncreaseRandomly();
        }

        private void GenerateEmptyParts()
        {
            _positionSpawn = (Vector2)_lastPart.transform.position + _lastPart.GetDistance/2 + partsLvl[0].GetDistance/2;
            for (int i = 0; i < countAdditionalParts; i++)
            {
                var part = _pool.GetPartLevel(typeof(BasePartLevel));
                part.transform.position = _positionSpawn;
                _positionSpawn += part.GetDistance;
                if (i == countAdditionalParts - 1)
                {
                    _lastPart = part;
                }
            }
        }
        private void IncreaseRandomly()
        {
            _currentLenghtLevel += Random.Range(2, 10);
        }

        private void OnDestroy()
        {
            Signals.Get<OnGenerateNextLevel>().RemoveListener(GenerateNewLevel);
        }
    }
}