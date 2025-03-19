using System.Reflection;
using Application_Manager.Events;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;

namespace Improved_Game_Manager.Tests {
    public class ApplicationEventTests
    {
        private int callbackInvocationCount;

        [SetUp]
        public void Setup()
        {
            callbackInvocationCount = 0;
        }

        [Test]
        public void ApplicationEvent_RaisesEvent_InvokesListenerResponse()
        {
            // Create a ScriptableObject instance of ApplicationEvent.
            var appEvent = ScriptableObject.CreateInstance<ApplicationEvent>();

            // Create an ApplicationEventListener instance.
            var appEventListener = ScriptableObject.CreateInstance<ApplicationEventListener>();

            // Create a UnityEvent and add a callback that increments our counter.
            appEventListener.Response = new UnityEvent();
            appEventListener.Response.AddListener(() => { callbackInvocationCount++; });

            // Assign the event to the listener.
            appEventListener.Event = appEvent;

            // Simulate enabling the listener so it registers with the event.
            MethodInfo onEnableMethod = appEventListener.GetType().GetMethod("OnEnable", BindingFlags.NonPublic | BindingFlags.Instance);
            onEnableMethod.Invoke(appEventListener, null);

            // Raise the event.
            appEvent.Raise();

            // Verify that the listener's callback was invoked.
            Assert.AreEqual(1, callbackInvocationCount);

            // Now simulate disabling the listener.
            MethodInfo onDisableMethod = appEventListener.GetType().GetMethod("OnDisable", BindingFlags.NonPublic | BindingFlags.Instance);
            onDisableMethod.Invoke(appEventListener, null);

            // Raise the event again; the callback should not be invoked.
            appEvent.Raise();
            Assert.AreEqual(1, callbackInvocationCount);
        }
    }
}