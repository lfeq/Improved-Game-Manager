using Application_Manager.Events;
using UnityEngine;

public class CreditsManager : MonoBehaviour {
    [SerializeField] private ApplicationEvent creditsEvent;
    [SerializeField] private ApplicationEvent goToMenuEvent;
    
    private void Start() {
        creditsEvent.Raise();
    }

    public void returnToMenu() {
        goToMenuEvent.Raise();
    }
}