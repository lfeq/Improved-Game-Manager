using Application_Manager.States;
using UnityEngine;
using UnityEngine.Events;

namespace Application_Manager.Events {
    [CreateAssetMenu(fileName = "New Application Event Listener",
        menuName = "Application Manager/Application Event Listener/ New Application Event Listener")]
    public class ApplicationEventListener : ScriptableObject {
        [Tooltip("Event to register with.")] 
        public ApplicationEvent Event;
        
        [Tooltip("State to change to when Event is raised.")]
        public BaseState stateToChangeTo;

        private void OnEnable() {
            if (Event == null) {
                return;
            }
            Event.RegisterListener(this);
        }

        private void OnDisable() {
            if (Event == null) {
                return;
            }
            Event.UnregisterListener(this);
        }

        public void OnEventRaised() {
            ApplicationManager.Instance.ChangeState(stateToChangeTo);
        }
    }
}