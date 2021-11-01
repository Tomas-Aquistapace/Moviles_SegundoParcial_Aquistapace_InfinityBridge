using UnityEngine;
using System;

public class PlayerState : MonoBehaviour
{
    public static Action LoseGame;
    public static Action<int> LoseLives;
    public static Action<int> EarnPoint;

    public enum State
    {
        Playing,
        Lose
    };
    [SerializeField] private State state;
    
    public int points = 0;

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
            Audio_Manager.instance.Play("Fall");

            LoseGame?.Invoke();

            SetNewMaxScore();
        }
    }

    public void UpdateLives(int lives)
    {
        LoseLives?.Invoke(lives);
    }

    public void WinPoints()
    {
        points++;

        EarnPoint?.Invoke(points);
    }

    void SetNewMaxScore()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        int oldPoints = data.points;

        if (oldPoints < points)
        {
            SaveSystem.SaveData(this);
        }
    }
}
