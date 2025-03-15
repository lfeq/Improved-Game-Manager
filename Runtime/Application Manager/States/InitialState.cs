using Application_Manager.Events;
using UnityEngine;

namespace Application_Manager.States {
    [CreateAssetMenu(fileName = "New Initial State", menuName = menuRootName + "Initial State")]
    public class InitialState : BaseState {
        
        public override void OnEnter() {
            base.OnEnter();
        }

        public override void OnExit() {
            base.OnExit();
        }
    }
}