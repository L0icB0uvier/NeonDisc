using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects.EventChannels
{
    [CreateAssetMenu(fileName = "Void Event Channel", menuName = "Events/VoidEventChannel", order = 0)]
    public class VoidEventChannel : ScriptableObject
    {
        public UnityAction onEventRaised;

        public void RaiseEvent()
        {
            onEventRaised?.Invoke();
        }
    }
}