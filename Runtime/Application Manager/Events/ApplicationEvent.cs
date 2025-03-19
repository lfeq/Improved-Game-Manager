using System.Collections.Generic;
    using UnityEngine;
    
    namespace Application_Manager.Events {
        /// <summary>
        /// Represents a scriptable object that acts as an event within the application.
        /// This class manages event listeners and handles event raising functionality.
        /// </summary>
        [CreateAssetMenu(fileName = "New Application Event",
            menuName = "Application Manager/Appplication Event/New Application Event")]
        public class ApplicationEvent : ScriptableObject {
            /// <summary>
            /// List of event listeners that will be notified when this event is raised.
            /// </summary>
            private readonly List<ApplicationEventListener> m_eventListeners = new();
    
            /// <summary>
            /// Raises the event, notifying all registered listeners.
            /// Iterates through the listeners in reverse order to safely handle any listeners
            /// that might be removed during event processing.
            /// </summary>
            public void Raise() {
                for (int i = m_eventListeners.Count - 1; i >= 0; i--)
                    m_eventListeners[i].OnEventRaised();
            }
    
            /// <summary>
            /// Registers a new listener to this event.
            /// </summary>
            /// <param name="t_listener">The listener to register.</param>
            /// <remarks>
            /// If the listener is already registered, it will not be added again.
            /// </remarks>
            public void RegisterListener(ApplicationEventListener t_listener) {
                if (!m_eventListeners.Contains(t_listener))
                    m_eventListeners.Add(t_listener);
            }
    
            /// <summary>
            /// Unregisters a listener from this event.
            /// </summary>
            /// <param name="t_listener">The listener to unregister.</param>
            /// <remarks>
            /// If the listener is not registered, the method will do nothing.
            /// </remarks>
            public void UnregisterListener(ApplicationEventListener t_listener) {
                if (m_eventListeners.Contains(t_listener))
                    m_eventListeners.Remove(t_listener);
            }
        }
    }