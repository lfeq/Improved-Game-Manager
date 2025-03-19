using Application_Manager.Events;
using Application_Manager.States;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public static MenuManager s_instance;
    [SerializeField] private ApplicationEvent menuEvent;
    [SerializeField] private ApplicationEvent startGameEvent;
    [SerializeField] private ApplicationEvent exitGameEvent;
    [SerializeField] private ChangingSceneState nextScene;

    private void Awake() {
        if (FindObjectOfType<MenuManager>() != null &&
            FindObjectOfType<MenuManager>().gameObject != gameObject) {
            Destroy(gameObject);
            return;
        }
        s_instance = this;
    }

    private void Start() {
        menuEvent.Raise();
    }

    public void startGame() {
        nextScene.sceneName = "Level1";
        startGameEvent.Raise();
        // GameManager.s_instance.setNewLevelName("Level1");
        // GameManager.s_instance.changeGameSate(GameState.LoadLevel);
    }

    public void exitGame() {
        exitGameEvent.Raise();
        // GameManager.s_instance.changeGameSate(GameState.QuitGame);
    }
}