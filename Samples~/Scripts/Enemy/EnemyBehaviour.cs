using System;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5f;
    
    private Rigidbody2D m_rb2d;
    private Vector2 m_direction;
    
    private void Start() {
        m_rb2d = GetComponent<Rigidbody2D>();
        resetDirection();
    }

    private void FixedUpdate() {
        m_rb2d.linearVelocity = m_direction * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D t_collision) {
        if (t_collision.CompareTag("Player")) {
            PlayerManager.instance.changePlayerSate(PlayerState.Dead);
            PlayerController.instance.enabled = false;
            LevelManager.instance.showGameOverScreen();
        }
    }

    public void resetDirection() {
        m_direction = (PlayerManager.instance.transform.position - transform.position).normalized;
    }
}