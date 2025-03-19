using Application_Manager.Events;
using UnityEngine;

namespace Application_Manager.States {
    /// <summary>
    /// Represents the base class for all application states.
    /// This abstract class provides common functionality for state management,
    /// including event listeners and debug logging.
    /// </summary>
    /// <remarks>
    /// Inherit from this class to create specific states for the application.
    /// </remarks>
    public abstract class BaseState : ScriptableObject, IState {
        [Tooltip("The event listener associated with this state.")]
        public ApplicationEventListener eventListener; 
        [Tooltip("The name of the state.")]
        public string stateName;
        protected const string MENU_ROOT_NAME = "Application Manager/States/";

        [Tooltip("Indicates whether debug mode is enabled for this state.")]
        [Space(50)]
        public bool debugMode;
        
        /// <summary>
        /// Called when the state becomes active. Initialize state-specific logic here.
        /// </summary>
        public virtual void OnEnter() {
            if (debugMode) {
                Debug.Log($"Entering {stateName} State");
            }
        }
        
        /// <summary>
        /// Called when the state is being exited. Clean up state-specific logic here.
        /// </summary>
        public virtual void OnExit() {
            if (debugMode) {
                Debug.Log($"Exiting {stateName} State");
            }
        }
    }
}