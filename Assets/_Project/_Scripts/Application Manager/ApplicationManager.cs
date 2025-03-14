using Application_Manager.State_Machine;
using Application_Manager.States;
using UnityCommunity.UnitySingleton;
using UnityEngine;

namespace Application_Manager {
    public class ApplicationManager : PersistentMonoSingleton<ApplicationManager> {
        [SerializeField] private BaseState initialState;
        
        private StateMachine m_stateMachine;

        private void Start() {
            m_stateMachine = new StateMachine();
            m_stateMachine.ChangeState(initialState);
        }
        
        public void ChangeState(BaseState t_state) {
            m_stateMachine.ChangeState(t_state);
        }
    }
}