using System;
using ScriptableObjects.EventChannels;
using UnityEngine;

namespace DefaultNamespace
{
    public class Respawner : MonoBehaviour
    {
        [SerializeField] private Transform respawnPosition;
        private Rigidbody2D m_rb2d;
        [SerializeField] private VoidEventChannel respawnEventChannel;

        private void Awake()
        {
            m_rb2d = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            respawnEventChannel.onEventRaised += Respawn;
        }

        private void OnDisable()
        {
            respawnEventChannel.onEventRaised -= Respawn;
        }

        private void Respawn()
        {
            m_rb2d.position = respawnPosition.position;
        }
    }
}