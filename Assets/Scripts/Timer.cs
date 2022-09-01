using System;
using GeneralScriptableObjects;
using ScriptableObjects.EventChannels;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI m_textCounter;
    
    [SerializeField] private FloatVariable timerValue;
    [SerializeField] private VoidEventChannel resetTimerEventChannel;
    
    private void Awake()
    {
        m_textCounter = GetComponent<TextMeshProUGUI>();
        resetTimerEventChannel.onEventRaised += ResetTimer;
    }

    private void OnDestroy()
    {
        resetTimerEventChannel.onEventRaised -= ResetTimer;
    }

    private void ResetTimer()
    {
        timerValue.SetValue(0);
        UpdateUI();
    }

    private void UpdateUI()
    {
        TimeSpan time = TimeSpan.FromSeconds(timerValue.Value);
        m_textCounter.text = time.ToString("mm':'ss':'ff");
    }
    
    void Update()
    {
        timerValue.ApplyChange(Time.deltaTime);
        UpdateUI();
    }
}
