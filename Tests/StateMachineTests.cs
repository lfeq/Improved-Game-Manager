using Application_Manager.State_Machine;
using Application_Manager.States;
using NUnit.Framework;

namespace Improved_Game_Manager.Tests {
    public class StateMachineTests
    {
        private class MockState : IState
        {
            public bool EnterCalled { get; private set; }
            public bool ExitCalled { get; private set; }

            public void OnEnter() => EnterCalled = true;
            public void OnExit() => ExitCalled = true;
        }

        [Test]
        public void ChangeState_TransitionsBetweenStates_CallsAppropriateMethods()
        {
            // Arrange
            var stateMachine = new StateMachine();
            var initialState = new MockState();
            var newState = new MockState();

            // Act
            stateMachine.ChangeState(initialState);
            stateMachine.ChangeState(newState);

            // Assert
            Assert.IsTrue(initialState.EnterCalled);
            Assert.IsTrue(initialState.ExitCalled);
            Assert.IsTrue(newState.EnterCalled);
        }
    }
}