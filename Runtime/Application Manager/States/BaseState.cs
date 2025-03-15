using Application_Manager.Events;
using UnityEngine;

namespace Application_Manager.States {
    public abstract class BaseState : ScriptableObject, IState {
        public ApplicationEventListener eventListener; 
        public string stateName;
        protected const string menuRootName = "Application Manager/States/";

        [Space(50)]
        public bool debugMode;
        
        public virtual void OnEnter() {
            if (debugMode) {
                Debug.Log($"Entering {stateName} State");
            }
        }
        public virtual void OnExit() {
            if (debugMode) {
                Debug.Log($"Exiting {stateName} State");
            }
        }
    }
}