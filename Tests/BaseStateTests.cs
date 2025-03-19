using NUnit.Framework;
using UnityEngine;

namespace Improved_Game_Manager.Tests {
    public class BaseStateTests
    {
        [Test]
        public void DummyState_OnEnterAndOnExit_SetsFlags()
        {
            // Create a dummy state.
            var dummyState = ScriptableObject.CreateInstance<DummyState>();

            // Initially, the flags should be false.
            Assert.IsFalse(dummyState.enterCalled);
            Assert.IsFalse(dummyState.exitCalled);

            // Invoke OnEnter and OnExit.
            dummyState.OnEnter();
            dummyState.OnExit();

            // Verify that the flags have been set.
            Assert.IsTrue(dummyState.enterCalled);
            Assert.IsTrue(dummyState.exitCalled);
        }
    }
}