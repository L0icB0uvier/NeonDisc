using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private GameObject firstSelected;
        
        private void OnEnable()
        {
            EventSystem.current.SetSelectedGameObject(firstSelected);
        }
    }
}