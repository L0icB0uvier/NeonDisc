using ScriptableObjects.EventChannels;
using UnityEngine;

namespace PowerUp
{
    public class DestroyWallsPowerUp : PowerUp
    {
        [SerializeField] private VoidEventChannel destroyWallsStartEventChannel;
        [SerializeField] private VoidEventChannel destroyWallsEndEventChannel;
        
        [SerializeField] private ColorEventChannel changeDiscColor;
        [SerializeField] private Color effectActiveColor;
        [SerializeField] private Color defaultColor;
        
        protected override void PickUp()
        {
            base.PickUp();
            changeDiscColor.RaiseEvent(effectActiveColor);
            destroyWallsStartEventChannel.RaiseEvent();
        }

        protected override void PowerUpEffectEnded()
        {
            changeDiscColor.RaiseEvent(defaultColor);
            destroyWallsEndEventChannel.RaiseEvent();
        }
    }
}