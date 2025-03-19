namespace Application_Manager.States {
    /// <summary>
    /// Defines the contracts for states in the application.
    /// States represent distinct phases or modes of the application lifecycle.
    /// </summary>
    public interface IState {
        /// <summary>
        /// Called when the state becomes active. Initialize state-specific logic here.
        /// </summary>
        void OnEnter();

        /// <summary>
        /// Called when the state is being exited. Clean up state-specific logic here.
        /// </summary>
        void OnExit();
    }
}