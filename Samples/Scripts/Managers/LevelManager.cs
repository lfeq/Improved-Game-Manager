using Application_Manager.Events;
using Cinemachine;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;

    [SerializeField] private CanvasGroup gameOverCanvasGroup;
    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private GameObject player;
    [SerializeField] private string nextLevelName;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private ApplicationEvent enteredLevelEvent;
    [SerializeField] private ApplicationEvent restartLevelEvent;
    [SerializeField] private ApplicationEvent goToMenuEvent;
    [SerializeField] private ApplicationEvent goToNextLevelEvent;

    private bool m_isShowingYouDiedScreen;

    private void Awake() {
        if (FindObjectOfType<LevelManager>() != null &&
            FindObjectOfType<LevelManager>().gameObject != gameObject) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        m_isShowingYouDiedScreen = false;
        gameOverCanvasGroup.alpha = 0;
        if (PlayerManager.instance == null) {
            Instantiate(player);
        }
    }

    private void Start() {
        // GameManager.s_instance.changeGameSate(GameState.Playing);
        enteredLevelEvent.Raise();
        PlayerManager.instance.transform.position = spawnPosition;
        PlayerManager.instance.changePlayerSate(PlayerState.Idle);
        PlayerController.instance.enabled = true;
        virtualCamera.Follow = PlayerManager.instance.transform;
    }

    private void Update() {
        showingGameOverScreen();
    }

    public void showGameOverScreen() {
        m_isShowingYouDiedScreen = true;
    }
    
    public void restartLevel() {
        Debug.Log("restartLevel");
        restartLevelEvent.Raise();
    }
    
    public void returnToMenu() {
        goToMenuEvent.Raise();
    }
    
    public void endLevel() {
        goToNextLevelEvent.Raise();
    }

    private void showingGameOverScreen() {
        if (!m_isShowingYouDiedScreen) {
            return;
        }
        gameOverCanvasGroup.alpha += Time.deltaTime;
    }
}