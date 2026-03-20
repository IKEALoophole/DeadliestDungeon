using UnityEngine;

public class PauseState : IGameState
{
    public void OnEnter()
    {
        Time.timeScale = 0f; // Pause the game
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
        Time.timeScale = 1f; // Resume the game
    }
}

