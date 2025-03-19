using Application_Manager.Events;
using UnityEngine;

/// <summary>
/// Clase encargada de toda la logica del Player, pero no del control
/// </summary>
public class PlayerManager : MonoBehaviour {

    /// <summary>
    /// Instancia publica de la clase PlayerManager
    /// </summary>
    public static PlayerManager instance;
    public GameObject interactableObject;
    public bool hasKey;

    [SerializeField] private GameObject promptObject;

    private Animator m_animator;
    private PlayerState m_playerState;
    private Rigidbody2D m_rb2d;

    private void Awake() {
        m_animator = GetComponent<Animator>();
        if (FindObjectOfType<PlayerManager>() != null &&
            FindObjectOfType<PlayerManager>().gameObject != gameObject) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    private void Start() {
        promptObject.SetActive(false);
        m_playerState = PlayerState.None;
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    public void changePlayerSate(PlayerState t_newSate) {
        if (m_playerState == t_newSate) {
            return;
        }
        resetAnimatorParameters();
        m_playerState = t_newSate;
        switch (m_playerState) {
            case PlayerState.None:
                break;
            case PlayerState.Idle:
                m_animator.SetBool("isIdeling", true);
                break;
            case PlayerState.Running:
                m_animator.SetBool("isRunning", true);
                break;
            case PlayerState.Jump:
                m_animator.SetBool("isJumpng", true);
                break;
            case PlayerState.JumpFall:
                m_animator.SetBool("isFalling", true);
                break;
            case PlayerState.FreeFall:
                m_animator.SetBool("isFalling", true);
                break;
            case PlayerState.Dead:
                m_rb2d.linearVelocity = new Vector2(0, 0);
                m_animator.SetBool("isDying", true);
                break;
        }
    }

    private void resetAnimatorParameters() {
        foreach (AnimatorControllerParameter parameter in m_animator.parameters) {
            if (parameter.type == AnimatorControllerParameterType.Bool) {
                m_animator.SetBool(parameter.name, false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D t_collision) {
        if (t_collision.CompareTag("Interactable")) {
            promptObject.SetActive(true);
            interactableObject = t_collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D t_collision) {
        if (t_collision.CompareTag("Interactable")) {
            promptObject.SetActive(false);
            interactableObject = null;
        }
    }

    public void getKey() {
        hasKey = true;
    }
}

public enum PlayerState {
    None,
    Idle,
    Running,
    Jump,
    JumpFall,
    FreeFall,
    Dead
}