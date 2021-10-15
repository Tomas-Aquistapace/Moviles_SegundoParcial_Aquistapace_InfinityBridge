using UnityEngine;
using System;

public class PlayerState : MonoBehaviour
{
    public static Action LoseGame;
    public static Action<int> EarnPoint;

    public enum State
    {
        Playing,
        Lose
    };
    [SerializeField] private State state;
    
    public static int points = 0;

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

    public void WinPoints()
    {
        points++;

        EarnPoint?.Invoke(points);
    }
}
