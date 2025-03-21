﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Application_Manager.States {
    [CreateAssetMenu(fileName = "New Changing Scene State", menuName = MENU_ROOT_NAME + "ChangingSceneState")]
    public class ChangingSceneState : BaseState {
        public string sceneName;

        public override void OnEnter() {
            base.OnEnter();
            SceneManager.LoadScene(sceneName);
        }
    }
}