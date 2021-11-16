using UnityEngine;
using System;

public class PlayerState : MonoBehaviour
{
    public static Action LoseGame;
    public static Action<int> LoseLives;
    public static Action<int> EarnPoint;
    public static Action<int> EarnCoin;

    public enum State
    {
        Playing,
        Lose
    };
    [SerializeField] private State state;

    // Score:
    public int points;
    public int coins;

    // Skins:
    [HideInInspector] public int skin;
    [HideInInspector] public bool froggy;
    [HideInInspector] public bool skelly;

    [Header("3D Model")]
    public MeshFilter meshFilter;

    // ============================

    private void Start()
    {
        skin = LoadData.GetActualSkin();

        meshFilter.mesh = LoadSkinAssets.GetSkin();
    }

    public State GetState()
    {
        return state;
    }

    public void SetState(State gameState)
    {
        state = gameState;

        if (state == State.Lose)
        {

#if UNITY_ANDROID
            Handheld.Vibrate();
#endif

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

        Audio_Manager.instance.Play("WinPoint");

        EarnPoint?.Invoke(points);
    }
    
    public void WinCoins()
    {
        coins++;

        Audio_Manager.instance.Play("WinCoin");

        EarnCoin?.Invoke(coins);
    }

    // ==================

    void SetNewMaxScore()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        int oldPoints = data.points;

        if (oldPoints > points)
        {
            points = oldPoints;
        }

        coins += data.coins;

        SaveSystem.SaveData(this);
    }

}
