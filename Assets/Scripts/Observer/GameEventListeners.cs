using UnityEngine;
using System;


    [Serializable]
    public class GameEventListeners : MonoBehaviour
    {
        public EventListener[] eventListeners;

        private void OnEnable()
        {
            foreach (EventListener eventListener in eventListeners)
            {
                eventListener.Event.RegisterListener(eventListener);
            }
        }

        private void OnDisable()
        {
            foreach (EventListener eventListener in eventListeners)
            {
                eventListener.Event.UnregisterListener(eventListener);
            }
        }
    }
