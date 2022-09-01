using ScriptableObjects.EventChannels;
using UnityEngine;
using UnityEngine.Events;

namespace SceneManagement
{
	public class StartGame : MonoBehaviour
	{
		[SerializeField] private LocationSO startGameLocation;

		[SerializeField] private bool _showLoadScreen;
	
		[Header("Broadcasting on")]
		[SerializeField] private LoadEventChannel _loadLocation;
		
		[SerializeField] private UnityEvent onGameStart;
		
		public void StartNewGame()
		{
			_loadLocation.RaiseEvent(startGameLocation, _showLoadScreen);
			onGameStart?.Invoke();
		}
	}
}
