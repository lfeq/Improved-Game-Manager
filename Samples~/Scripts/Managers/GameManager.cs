using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager s_instance;

    private GameState m_gameState;
    private string m_newLevel;

    private void Awake() {
        if (s_instance != null && s_instance != this) {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        s_instance = this;
        m_gameState = GameState.None;
    }

    public void changeGameSate(GameState t_newState) {
        if (m_gameState == t_newState) {
            return;
        }
        m_gameState = t_newState;
        switch (m_gameState) {
            case GameState.None:
                break;
            case GameState.LoadMainMenu:
                loadMenu();
                break;
            case GameState.MainMenu:
                break;
            case GameState.LoadLevel:
                loadLevel();
                break;
            case GameState.Playing:
                break;
            case GameState.RestartLevel:
                restartLevel();
                break;
            case GameState.GameOver:
                break;
            case GameState.Credits:
                break;
            case GameState.QuitGame:
                quitGame();
                break;
            default:
                throw new UnityException("Invalid Game State");
        }
    }

    public void changeGameStateInEditor(string t_newState) {
        changeGameSate((GameState)System.Enum.Parse(typeof(GameState), t_newState));
    }

    public GameState getGameState() {
        return m_gameState;
    }

    public void setNewLevelName(string t_newLevel) {
        m_newLevel = t_newLevel;
    }

    public void loadMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    private void restartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void loadLevel() {
        SceneManager.LoadScene(m_newLevel);
    }

    private void quitGame() {
        Application.Quit();
    }
}

public enum GameState {
    None,
    LoadMainMenu,
    MainMenu,
    LoadLevel,
    Playing,
    RestartLevel,
    GameOver,
    Credits,
    QuitGame,
}