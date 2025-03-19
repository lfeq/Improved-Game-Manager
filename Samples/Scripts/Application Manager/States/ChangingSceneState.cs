using Application_Manager.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Application_Manager.States {
    [CreateAssetMenu(fileName = "New Changing Scene State", menuName = menuRootName + "ChangingSceneState")]
    public class ChangingSceneState : BaseState {
        public string sceneName;

        public override void OnEnter() {
            base.OnEnter();
            SceneManager.LoadScene(sceneName);
        }
    }
}