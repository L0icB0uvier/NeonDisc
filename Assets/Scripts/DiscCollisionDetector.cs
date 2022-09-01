using System.Collections;
using Lean.Pool;
using ScriptableObjects.EventChannels;
using UnityEngine;

public class DiscCollisionDetector : MonoBehaviour
{
    [SerializeField] private bool destroyModeOn;
    
    [SerializeField] private VoidEventChannel gameOverEventChannel;
    [SerializeField] private VoidEventChannel destroyDiscsStartEventChannel;
    [SerializeField] private VoidEventChannel destroyDiscsEndEventChannel;
    
    private void OnEnable()
    {
        destroyDiscsStartEventChannel.onEventRaised += ActivateDestroyMode;
        destroyDiscsEndEventChannel.onEventRaised += DeactivateDestroyMode;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (destroyModeOn)
        {
            LeanPool.Despawn(other.gameObject);
        }
        else
        {
            gameOverEventChannel.RaiseEvent();
        }
    }

    private void ActivateDestroyMode()
    {
        destroyModeOn = true;
    }

    private void DeactivateDestroyMode()
    {
        destroyModeOn = false;
    }
}