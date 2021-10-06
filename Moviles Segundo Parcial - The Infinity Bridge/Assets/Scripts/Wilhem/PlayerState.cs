using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{   
    public enum State
    {
        Playing,
        Lose
    };
    [SerializeField] private State state;

    public void SetState(State gameState)
    {
        state = gameState;
    }

    public State GetState()
    {
        return state;
    }
}
