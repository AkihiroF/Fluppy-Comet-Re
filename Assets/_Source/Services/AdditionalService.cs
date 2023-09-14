using UnityEngine;

namespace _Source.Services
{
    public static class AdditionalService
    {
        public static bool CheckLayer(this LayerMask original, int toCheck)
        {
            return (original.value & (1 << toCheck)) > 0;
        }
    }
}