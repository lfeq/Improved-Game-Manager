using System.Collections;
using System.Reflection;
using Application_Manager;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Improved_Game_Manager.Tests {
    // A simple dummy state that tracks whether OnEnter and OnExit are called.

    public class ApplicationManagerTests
    {
        private GameObject testGameObject;

        [SetUp]
        public void Setup()
        {
            // Create a fresh GameObject for each test.
            testGameObject = new GameObject("TestApplicationManager");
        }

        [TearDown]
        public void Teardown()
        {
            // Clean up our GameObjects.
            if (testGameObject != null)
            {
                Object.DestroyImmediate(testGameObject);
            }
            // Also destroy the ApplicationManager singleton if it was created.
            if (ApplicationManager.Instance != null)
            {
                Object.DestroyImmediate(ApplicationManager.Instance.gameObject);
            }
        }

        [Test]
        public void ApplicationManager_InitializesWithInitialState()
        {
            // Create a dummy state instance.
            var dummyState = ScriptableObject.CreateInstance<DummyState>();

            // Add ApplicationManager to the test GameObject.
            var appManager = testGameObject.AddComponent<ApplicationManager>();

            // Set the private "initialState" field via reflection.
            FieldInfo initialStateField = typeof(ApplicationManager).GetField("initialState", BindingFlags.NonPublic | BindingFlags.Instance);
            initialStateField.SetValue(appManager, dummyState);

            // Manually invoke Awake (since Unity normally calls this automatically).
            MethodInfo awakeMethod = typeof(ApplicationManager).GetMethod("Awake", BindingFlags.NonPublic | BindingFlags.Instance);
            awakeMethod.Invoke(appManager, null);

            // Verify that the current state is the dummyState.
            Assert.AreEqual(dummyState, appManager.GetCurrentState());
        }

        [Test]
        public void ApplicationManager_ChangeState_UpdatesCurrentState()
        {
            // Create two dummy state instances.
            var dummyState1 = ScriptableObject.CreateInstance<DummyState>();
            var dummyState2 = ScriptableObject.CreateInstance<DummyState>();

            // Add ApplicationManager and assign initial state.
            var appManager = testGameObject.AddComponent<ApplicationManager>();
            FieldInfo initialStateField = typeof(ApplicationManager).GetField("initialState", BindingFlags.NonPublic | BindingFlags.Instance);
            initialStateField.SetValue(appManager, dummyState1);

            // Call Awake so that the initial state is set.
            MethodInfo awakeMethod = typeof(ApplicationManager).GetMethod("Awake", BindingFlags.NonPublic | BindingFlags.Instance);
            awakeMethod.Invoke(appManager, null);

            // Check the initial state.
            Assert.AreEqual(dummyState1, appManager.GetCurrentState());

            // Change the state to dummyState2.
            appManager.ChangeState(dummyState2);

            // Verify that the current state is now dummyState2.
            Assert.AreEqual(dummyState2, appManager.GetCurrentState());
        }
    }
}