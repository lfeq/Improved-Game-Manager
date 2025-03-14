namespace Application_Manager.States {
    public interface IState {
        void OnEnter();
        void OnExit();
    }
}