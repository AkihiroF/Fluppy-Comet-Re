using UnityEngine;

namespace GeneratorLevel
{
    public class CreatorPartsLevel : MonoBehaviour
    {
        public static GameObject CreatePart(GameObject reference) => Instantiate(reference);
    }
}