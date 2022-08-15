using System;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(menuName = "Events/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        [NonSerialized] private List<EventListener> eventListeners = new List<EventListener>();

        public void Raise()
        {
            for (int i=0; i<eventListeners.Count; i++ )
            {
                eventListeners[i].OnEventRaised(eventListeners[i].Response);
            }
        }

        public void RegisterListener(EventListener eventListener)
        {
            if (!eventListeners.Contains(eventListener)) eventListeners.Add(eventListener);
        }

        public void UnregisterListener(EventListener eventListener)
        {
            if (eventListeners.Contains(eventListener)) eventListeners.Remove(eventListener);
        }
    }
