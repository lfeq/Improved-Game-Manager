using UnityEngine;

/// <summary>
/// Se encarga el control del player, pero no de la logica de juego
/// </summary>
[RequireComponent(typeof(PlayerManager))]
public class PlayerController : MonoBehaviour {


    #region Public
    /// <summary>
    /// Instancia singleton de PlayerController
    /// </summary>
    public static PlayerController instance;
    public LayerMask whatIsGround;
    #endregion

    #region Private
    private Rigidbody2D m_rb2D;
    private bool m_isFacingRight, m_isGrounded;
    #endregion

    #region Serialize Fields
    [SerializeField] private float xSpeed, jumpForce, footRadious;
    [SerializeField] private Transform footPosition;
    #endregion

    private void Awake() {
        instance = this;
        m_isFacingRight = true;
        m_isGrounded = false;
    }

    // Start is called before the first frame update
    void Start() {
        m_rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        m_isGrounded = Physics2D.OverlapCircle(footPosition.position, footRadious, whatIsGround) &&
                                m_rb2D.linearVelocity.y < 0.1f;

        horizontalMovement();
        verticalMovement();
    }

    private void horizontalMovement() {
        float xMove = Input.GetAxisRaw("Horizontal");
        m_rb2D.linearVelocity = new Vector2(xMove * xSpeed, m_rb2D.linearVelocity.y);
        if ((xMove < 0 && m_isFacingRight) || (xMove > 0 && !m_isFacingRight)) {
            flip();
        }
        if (m_isGrounded) {
            if (xMove != 0) {
                PlayerManager.instance.changePlayerSate(PlayerState.Running);
            } else if (xMove == 0) {
                PlayerManager.instance.changePlayerSate(PlayerState.Idle);
            }
        }
    }

    private void verticalMovement() {
        if (m_isGrounded) {
            return;
        }
        if (m_rb2D.linearVelocity.y >= 0.1f) {
            PlayerManager.instance.changePlayerSate(PlayerState.Jump);
        } else if (m_rb2D.linearVelocity.y < -0.1f) {
            PlayerManager.instance.changePlayerSate(PlayerState.JumpFall);
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Jump")) {
            jump();
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            if(PlayerManager.instance.interactableObject != null) {
                ItemBehaviour handleBehaviour = PlayerManager.instance.interactableObject.GetComponent<ItemBehaviour>();

                if(handleBehaviour != null) {
                    if(!handleBehaviour.requiresKey) {
                        handleBehaviour.onActivate.Invoke();
                    } else {
                        if (PlayerManager.instance.hasKey) {
                            handleBehaviour.onActivate.Invoke();
                        }
                    }
                }
            }
        }
    }

    private void jump() {
        if (!m_isGrounded) {
            return;
        }
        m_rb2D.linearVelocity = new Vector2(m_rb2D.linearVelocity.x, jumpForce);
    }

    private void flip() {
        transform.Rotate(0, 180, 0);
        m_isFacingRight = !m_isFacingRight;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(footPosition.position, footRadious);
    }
}