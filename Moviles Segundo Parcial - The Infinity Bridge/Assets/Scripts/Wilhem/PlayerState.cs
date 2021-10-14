using UnityEngine;
using System;

public class PlayerState : MonoBehaviour
{
    public static Action LoseGame;

    public enum State
    {
        Playing,
        Lose
    };
    [SerializeField] private State state;
    
    // ============================

    public State GetState()
    {
        return state;
    }

    public void SetState(State gameState)
    {
        state = gameState;

        if (state == State.Lose)
        {
            LoseGame?.Invoke();
        }
    }
}
