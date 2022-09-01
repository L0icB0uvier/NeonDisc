using System;
using GeneralScriptableObjects;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TimerDisplay : MonoBehaviour
    {
        private TextMeshProUGUI m_timerUI;
        
        [SerializeField] private FloatVariable timerValue;

        private void Awake()
        {
            m_timerUI = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            TimeSpan time = TimeSpan.FromSeconds(timerValue.Value);
            m_timerUI.text = time.ToString("mm':'ss':'ff");
        }
    }
}