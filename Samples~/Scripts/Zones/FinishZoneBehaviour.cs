using Application_Manager.Events;
using UnityEngine;

namespace Zones {
    public class FinishZoneBehaviour : MonoBehaviour {
        [SerializeField] private ApplicationEvent goToNextLevelEvent;
        
        private void OnTriggerEnter2D(Collider2D t_collision) {
            if (t_collision.CompareTag("Player")) {
                Debug.Log("Player has reached the finish zone");
                goToNextLevelEvent.Raise();
            }
        }
    }
}