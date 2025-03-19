using UnityEngine;

public class DeadzoneBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D t_collision) {
        if (t_collision.CompareTag("Player")) {
            PlayerManager.instance.changePlayerSate(PlayerState.Dead);
            PlayerController.instance.enabled = false;
            LevelManager.instance.showGameOverScreen();
        }
    }
}
