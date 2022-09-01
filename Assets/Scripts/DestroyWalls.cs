using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.EventChannels;
using UnityEngine;

public class DestroyWalls : MonoBehaviour
{
    [SerializeField] private Vector2EventChannel destroyWallEventChannel;

    [SerializeField] private VoidEventChannel destroyWallStartEventChannel;
    [SerializeField] private VoidEventChannel destroyWallEndEventChannel;

    private bool m_destroyWalls = false;
    
    private void Awake()
    {
        destroyWallStartEventChannel.onEventRaised += Activate;
        destroyWallEndEventChannel.onEventRaised += Deactivate;
        Deactivate();
    }

    private void Activate()
    {
        m_destroyWalls = true;
    }

    private void Deactivate()
    {
        m_destroyWalls = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (m_destroyWalls == false) return;
        
        List<ContactPoint2D> contacts = new List<ContactPoint2D>();
        other.GetContacts(contacts);
        foreach (var contact in contacts)
        {
            destroyWallEventChannel.RaiseEvent(contact.point);
        }
    }
}
