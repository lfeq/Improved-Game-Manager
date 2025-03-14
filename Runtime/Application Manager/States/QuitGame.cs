﻿using UnityEngine;

namespace Application_Manager.States {
    [CreateAssetMenu(menuName = menuRootName + "Quit Game")]
    public class QuitGame : BaseState{
        public override void OnEnter() {
            Debug.Log("Entering Quit Game State");
            Application.Quit();
        }
    }
}