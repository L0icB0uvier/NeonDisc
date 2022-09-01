using System;
using System.Collections;
using Lean.Pool;
using Unity.VisualScripting;
using UnityEngine;
using IPoolable = Lean.Pool.IPoolable;

namespace PowerUp
{
    public abstract class PowerUp : MonoBehaviour, IPoolable
    {
        [SerializeField] private float powerUpDuration;
        private SpriteRenderer m_rend;
        private Collider2D m_col;

        private void Awake()
        {
            m_rend = GetComponent<SpriteRenderer>();
            m_col = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PickUp();
            }
        }

        private void OnEnable()
        {
            m_rend.enabled = true;
            m_col.enabled = true;
        }

        protected virtual void PickUp()
        {
            m_rend.enabled = false;
            m_col.enabled = false;
            LeanPool.Despawn(gameObject, powerUpDuration);
        }
        
        protected abstract void PowerUpEffectEnded();
        

        public void OnSpawn()
        {
            
        }

        public void OnDespawn()
        {
            PowerUpEffectEnded();
        }
    }
}