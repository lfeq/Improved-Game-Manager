using Application_Manager.States;

namespace Application_Manager.State_Machine {
    /// <summary>
    /// Handles transitions between application states using the state machine pattern.
    /// </summary>
    public class StateMachine {
        /// <summary>
        /// Gets the current active state.
        /// </summary>
        public IState CurrentState => m_currentState;
        private IState m_currentState;
        
        /// <summary>
        /// Switches the current state to a new state.
        /// </summary>
        /// <param name="t_newState">The new state to transition into.</param>
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