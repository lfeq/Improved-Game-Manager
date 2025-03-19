using Application_Manager.States;
using UnityEngine;
using UnityEngine.Events;

namespace Application_Manager.Events {
    [CreateAssetMenu(fileName = "New Application Event Listener",
        menuName = "Application Manager/Application Event Listener/ New Application Event Listener")]
    public class ApplicationEventListener : ScriptableObject {
        [Tooltip("Event to register with.")] public ApplicationEvent Event;
        
        // TODO: Probably should just call ChangeState directly from the event
        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;

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
            Response.Invoke();
        }

        public void ChangeState(BaseState t_state) {
            ApplicationManager.Instance.ChangeState(t_state);
        }
    }
}