using System.Collections.Generic;
using UnityEngine;

namespace Application_Manager.Events {
    [CreateAssetMenu(fileName = "New Application Event", menuName = "Application Event")]
    public class ApplicationEvent : ScriptableObject {
        private readonly List<ApplicationEventListener> eventListeners = 
            new List<ApplicationEventListener>();

        public void Raise()
        {
            for(int i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised();
        }

        public void RegisterListener(ApplicationEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(ApplicationEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        } 
    }
}