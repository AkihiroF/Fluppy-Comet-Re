using System;
using System.Collections.Generic;
using _Source.GeneratorLevel.Parts;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace _Source.GeneratorLevel
{
    public class PoolPartsLevel
    {
        private List<APartLevel> _parts;

        public PoolPartsLevel()
        {
            _parts = new List<APartLevel>();
        }

        public APartLevel GetPartLevel()
        {
            try
            {
                if (_parts.Count > 1)
                {
                    int randomIndex = Random.Range(1, _parts.Count);
                    APartLevel part = _parts[randomIndex];
                    _parts.Remove(part);
                    return part;
                }
                else if (_parts.Count == 1)
                {
                    // Создаем новый экземпляр, если в пуле только один элемент
                    APartLevel newPart = Object.Instantiate(_parts[0].GetObject).GetComponent<APartLevel>();
                    return newPart;
                }
                else
                {
                    // Возвращаем null или выбрасываем исключение, если пул пуст
                    Debug.LogError("Pool is empty");
                    return null;
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }


        public void AddToPool(APartLevel objectPart)
        {
            _parts.Add(objectPart);
        }
    }
}