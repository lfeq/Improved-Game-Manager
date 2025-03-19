using Application_Manager.States;

namespace Improved_Game_Manager.Tests {
    public class DummyState : BaseState
    {
        public bool enterCalled = false;
        public bool exitCalled = false;

        public override void OnEnter()
        {
            base.OnEnter();
            enterCalled = true;
        }

        public override void OnExit()
        {
            base.OnExit();
            exitCalled = true;
        }
    }
}