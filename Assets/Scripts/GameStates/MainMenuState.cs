using UnityEngine;

public class MainMenuState : IGameState
{
    public void OnEnter()
    {
        GameManager.Instance.SetScene("MainMenu");
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {

    }
}
