using Application_Manager.States;
using UnityEngine;

namespace Application_Manager.Events {
    /// <summary>
    /// Listens for application events and triggers a state change when the event is raised.
    /// </summary>
    [CreateAssetMenu(fileName = "New Application Event Listener",
        menuName = "Application Manager/Application Event Listener/ New Application Event Listener")]
    public class ApplicationEventListener : ScriptableObject {
        [Tooltip("Event to register with.")] 
        public ApplicationEvent Event;
        
        [Tooltip("State to change to when Event is raised."), RequireInterface(typeof(IState))]
        public ScriptableObject stateToChangeTo;

        /// <summary>
        /// Registers the listener with the event when the listener is enabled.
        /// </summary>
        private void OnEnable() {
            if (Event == null) {
                return;
            }
            Event.RegisterListener(this);
        }

        /// <summary>
        /// Unregisters the listener from the event when the listener is disabled.
        /// </summary>
        private void OnDisable() {
            if (Event == null) {
                return;
            }
            Event.UnregisterListener(this);
        }

        /// <summary>
        /// Called when the event is raised. Changes the application state to the specified state.
        /// </summary>
        public void OnEventRaised() {
            ApplicationManager.Instance.ChangeState(stateToChangeTo as IState);
        }
    }
}