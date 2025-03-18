using Application_Manager.States;

namespace Application_Manager.State_Machine {
    public class StateMachine {
        public IState CurrentState => m_currentState;
        private IState m_currentState;
        
        public void ChangeState(IState t_newState) {
            if (t_newState == m_currentState) {
                return;
            }
            m_currentState?.OnExit();
            m_currentState = t_newState;
            m_currentState.OnEnter();
        }
    }
}