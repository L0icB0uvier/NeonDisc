using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.EventChannels;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
   [SerializeField] private ColorEventChannel onChangeColorEvent;
   private SpriteRenderer m_rend;
   
   private void Awake()
   {
      m_rend = GetComponent<SpriteRenderer>();
      onChangeColorEvent.onEventRaised += ONEventRaised;
   }

   private void OnDestroy()
   {
      onChangeColorEvent.onEventRaised -= ONEventRaised;
   }

   private void ONEventRaised(Color col)
   {
      m_rend.color = col;
   }
}
