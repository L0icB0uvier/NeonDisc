using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects.EventChannels
{
    [CreateAssetMenu(fileName = "Bool event channel", menuName = "Events/BoolEventChannel", order = 0)]
    public class BoolEventChannel : ScriptableObject
    {
        public UnityAction<bool> onEventRaised;

        public void RaiseEvent(bool val)
        {
            onEventRaised?.Invoke(val);
        }
    }
}