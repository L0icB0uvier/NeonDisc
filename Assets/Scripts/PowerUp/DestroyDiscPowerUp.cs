using ScriptableObjects.EventChannels;
using UnityEngine;

namespace PowerUp
{
    public class DestroyDiscPowerUp : PowerUp
    {
        [SerializeField] private VoidEventChannel destroyDiscStartedEventChannel;
        [SerializeField] private VoidEventChannel destroyDiscEndedEventChannel;
        
        [SerializeField] private ColorEventChannel changeDiscColor;
        [SerializeField] private ColorEventChannel changePlayerColor;

        [SerializeField] private Color redColor;
        [SerializeField] private Color blueColor;
        
        protected override void PickUp()
        {
            base.PickUp();
            destroyDiscStartedEventChannel.RaiseEvent();
            changePlayerColor.RaiseEvent(redColor);
            changeDiscColor.RaiseEvent(blueColor);
        }

        protected override void PowerUpEffectEnded()
        {
            destroyDiscEndedEventChannel.RaiseEvent();
            changePlayerColor.RaiseEvent(blueColor);
            changeDiscColor.RaiseEvent(redColor);
        }
    }
}