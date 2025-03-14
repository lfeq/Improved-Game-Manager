﻿using UnityEngine;

namespace Application_Manager.States {
    public abstract class BaseState : ScriptableObject, IState {
        public virtual void OnEnter() {
            // Noop
        }
        public virtual void OnExit() {
            // Noop
        }
    }
}