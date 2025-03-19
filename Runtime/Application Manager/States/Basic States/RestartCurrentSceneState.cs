using UnityEngine;
using UnityEngine.SceneManagement;

namespace Application_Manager.States {
    [CreateAssetMenu(fileName = "New Restart Current Scene State", menuName = MENU_ROOT_NAME + "Restarting Scene State")]
    public class RestartCurrentSceneState : BaseState {
        public override void OnEnter() {
            base.OnEnter();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}