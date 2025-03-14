using Application_Manager.Events;
using UnityEngine;

namespace Application_Manager.States {
    [CreateAssetMenu(fileName = "New Initial State", menuName = menuRootName + "Initial State")]
    public class InitialState : BaseState {
        public ApplicationEventListener eventListener;
        
        public override void OnEnter() {
            Debug.Log("Entering Initial State");
        }

        public override void OnExit() {
            Debug.Log("Exiting Initial State");
        }
        
        public override void ChangeState(BaseState state) {
            Debug.Log("Changing Initial State");
            ApplicationManager.Instance.ChangeState(state);
        }
    }
}