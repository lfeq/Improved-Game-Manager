namespace Application_Manager.States {
    public abstract class BaseState : IState {
        public virtual void OnEnter() {
            // Noop
        }
        public virtual void OnExit() {
            // Noop
        }
    }
}