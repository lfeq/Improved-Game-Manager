using System.Reflection;
using Application_Manager;
using Application_Manager.Events;
using NUnit.Framework;
using UnityEngine;

namespace Improved_Game_Manager.Tests {
    public class ApplicationEventTests {
        private GameObject testManagerGO;

        [SetUp]
        public void Setup() {
            // Create a new GameObject to host the ApplicationManager singleton.
            testManagerGO = new GameObject("TestApplicationManager");
        }

        [TearDown]
        public void Teardown() {
            if (testManagerGO != null) {
                Object.DestroyImmediate(testManagerGO);
            }
            if (ApplicationManager.Instance != null) {
                Object.DestroyImmediate(ApplicationManager.Instance.gameObject);
            }
        }

        [Test]
        public void ApplicationEvent_RaisesEvent_ChangesStateInApplicationManager() {
            // Create an ApplicationManager instance on our test GameObject.
            var appManager = testManagerGO.AddComponent<ApplicationManager>();

            // Create an initial dummy state and set it as the initial state using reflection.
            var initialState = ScriptableObject.CreateInstance<DummyState>();
            FieldInfo initialStateField = typeof(ApplicationManager)
                .GetField("initialState", BindingFlags.NonPublic | BindingFlags.Instance);
            initialStateField.SetValue(appManager, initialState);

            // Manually call Awake() to initialize the state machine.
            MethodInfo awakeMethod = typeof(ApplicationManager)
                .GetMethod("Awake", BindingFlags.NonPublic | BindingFlags.Instance);
            awakeMethod.Invoke(appManager, null);

            // Verify that the current state is the initial state.
            Assert.AreEqual(initialState, appManager.GetCurrentState());

            // Create an ApplicationEvent and an ApplicationEventListener.
            var appEvent = ScriptableObject.CreateInstance<ApplicationEvent>();
            var appEventListener = ScriptableObject.CreateInstance<ApplicationEventListener>();

            // Create a dummy state that the listener will switch to when the event is raised.
            var targetState = ScriptableObject.CreateInstance<DummyState>();
            appEventListener.stateToChangeTo = targetState;

            // Assign the event to the listener.
            appEventListener.Event = appEvent;

            // Simulate enabling the listener (registers it with the event).
            MethodInfo onEnableMethod = appEventListener.GetType()
                .GetMethod("OnEnable", BindingFlags.NonPublic | BindingFlags.Instance);
            onEnableMethod.Invoke(appEventListener, null);

            // Raise the event; this should trigger the listener to change the state.
            appEvent.Raise();

            // Verify that ApplicationManager's current state has been updated to the target state.
            Assert.AreEqual(targetState, appManager.GetCurrentState());

            // Now disable the listener.
            MethodInfo onDisableMethod = appEventListener.GetType()
                .GetMethod("OnDisable", BindingFlags.NonPublic | BindingFlags.Instance);
            onDisableMethod.Invoke(appEventListener, null);

            // Change state back to initial state manually.
            appManager.ChangeState(initialState);
            Assert.AreEqual(initialState, appManager.GetCurrentState());

            // Raise the event again; since the listener is disabled, the state should remain unchanged.
            appEvent.Raise();
            Assert.AreEqual(initialState, appManager.GetCurrentState());
        }
    }
}