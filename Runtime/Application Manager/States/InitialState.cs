using Application_Manager.Events;
using UnityEngine;

namespace Application_Manager.States {
    // TODO: All Create Asset Menu should be in the menu name "Application Manager/..."
    [CreateAssetMenu(fileName = "New Initial State", menuName = "States/Initial State")]
    public class InitialState : BaseState {
        public ApplicationEventListener eventListener;
        
        public override void OnEnter() {
            Debug.Log("Entering Initial State");
        }

        public override void OnExit() {
            Debug.Log("Exiting Initial State");
        }
        
        // TODO: this should go in the base class
        public void ChangeState(BaseState state) {
            Debug.Log("Changing Initial State");
            ApplicationManager.Instance.ChangeState(state);
        }
    }
}