using Application_Manager.State_Machine;
using Application_Manager.States;
using UnityCommunity.UnitySingleton;
using UnityEngine;

namespace Application_Manager {
    /// <summary>
    /// Manages the application's state machine as a persistent singleton.
    /// This class handles state transitions and maintains the current state of the application.
    /// </summary>
    public class ApplicationManager : PersistentMonoSingleton<ApplicationManager> {
        [Tooltip(
            "The initial state of the application when it starts." +
            "This state will be set immediately after the ApplicationManager is initialized.")]
        [SerializeField]
        private BaseState initialState;

        /// <summary>
        /// The state machine instance that handles state transitions.
        /// </summary>
        private StateMachine m_stateMachine;

        /// <summary>
        /// Initializes the ApplicationManager and sets up the state machine.
        /// If an initial state is provided, the state machine will transition to it.
        /// </summary>
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

        /// <summary>
        /// Gets the current state of the application.
        /// </summary>
        /// <returns>The current BaseState of the application, or null if no state is set.</returns>
        public BaseState GetCurrentState() {
            return m_stateMachine.CurrentState as BaseState;
        }

        /// <summary>
        /// Changes the current state of the application to a new state.
        /// </summary>
        /// <param name="t_newState">The new state to transition to.</param>
        public void ChangeState(BaseState t_newState) {
            m_stateMachine.ChangeState(t_newState);
        }
    }
}