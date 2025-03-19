using Application_Manager;
using Application_Manager.Events;
using Application_Manager.States;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New MainMenu State", menuName = menuRootName + "MainMenuState")]
public class MainMenuState : BaseState {
    
    public override void OnEnter() {
        base.OnEnter();
        SceneManager.LoadScene("MainMenu");
    }
}