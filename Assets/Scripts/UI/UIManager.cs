using ScriptableObjects.EventChannels;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel gameOverEventChannel;
        [SerializeField] private VoidEventChannel restartGameEventChannel;
        [SerializeField] private BoolEventChannel pauseEventChannel;
    
        [SerializeField] private GameObject GameOverUI;
        [SerializeField] private GameObject timerUI;
        
        private void Awake()
        {
            gameOverEventChannel.onEventRaised += ShowGameOverUI;
            restartGameEventChannel.onEventRaised += HideGameOverUI;
        }

        private void OnDestroy()
        {
            gameOverEventChannel.onEventRaised -= ShowGameOverUI;
            restartGameEventChannel.onEventRaised -= HideGameOverUI;
        }

        private void ShowGameOverUI()
        {
            GameOverUI.SetActive(true);
            timerUI.SetActive(false);
            pauseEventChannel.RaiseEvent(true);
        }

        private void HideGameOverUI()
        {
            GameOverUI.SetActive(false);
            timerUI.SetActive(true);
            pauseEventChannel.RaiseEvent(false);
        }
    }
}
