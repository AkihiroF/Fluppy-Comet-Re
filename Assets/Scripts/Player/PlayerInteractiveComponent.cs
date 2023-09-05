using System;
using deVoid.Utils;
using Events;
using Services;
using UnityEngine;

namespace Player
{
    public class PlayerInteractiveComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask layerCoin;
        [SerializeField] private LayerMask layerDie;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var obj = other.gameObject;
            if(layerCoin.CheckLayer(obj.layer))
            {
                Signals.Get<OnGetCoin>().Dispatch();
                obj.SetActive(false);
            }
            if(layerDie.CheckLayer(obj.layer))
                Signals.Get<OnDie>().Dispatch();
        }
    }
}