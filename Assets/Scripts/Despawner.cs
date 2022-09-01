using System;
using Lean.Pool;
using ScriptableObjects.EventChannels;
using UnityEngine;

namespace DefaultNamespace
{
    public class Despawner : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel despawnEventChannel;

        private void OnEnable()
        {
            despawnEventChannel.onEventRaised += Despawn;
        }

        private void OnDisable()
        {
            despawnEventChannel.onEventRaised -= Despawn;
        }

        private void Despawn()
        {
            LeanPool.Despawn(gameObject);
        }
    }
}