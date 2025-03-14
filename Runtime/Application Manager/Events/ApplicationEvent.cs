using System.Collections.Generic;
using UnityEngine;

namespace Application_Manager.Events {
    [CreateAssetMenu(fileName = "New Application Event",
        menuName = "Application Manager/Appplication Event/New Application Event")]
    public class ApplicationEvent : ScriptableObject {
        private readonly List<ApplicationEventListener> m_eventListeners =
            new List<ApplicationEventListener>();

        public void Raise() {
            for (int i = m_eventListeners.Count - 1; i >= 0; i--)
                m_eventListeners[i].OnEventRaised();
        }

        public void RegisterListener(ApplicationEventListener listener) {
            if (!m_eventListeners.Contains(listener))
                m_eventListeners.Add(listener);
        }

        public void UnregisterListener(ApplicationEventListener listener) {
            if (m_eventListeners.Contains(listener))
                m_eventListeners.Remove(listener);
        }
    }
}