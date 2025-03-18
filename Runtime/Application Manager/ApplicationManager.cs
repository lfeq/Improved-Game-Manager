using Application_Manager.State_Machine;
using Application_Manager.States;
using UnityCommunity.UnitySingleton;
using UnityEngine;

namespace Application_Manager {
    public class ApplicationManager : PersistentMonoSingleton<ApplicationManager> {
        [SerializeField] private BaseState initialState;
        
        private StateMachine m_stateMachine;

        protected override void Awake() {
            base.Awake();
            if (Instance != this) {
                return;
            }
            m_stateMachine = new StateMachine();
            if (initialState != null) {
                m_stateMachine.ChangeState(initialState);
            }
        }
        
        public BaseState GetCurrentState() {
            return m_stateMachine.CurrentState as BaseState;
        }

        public void ForceChangeState(BaseState t_newState) {
            m_stateMachine.ForceChangeState(t_newState);
        }
        
        public void ChangeState(BaseState t_newState) {
            m_stateMachine.ChangeState(t_newState);
        }
    }
}