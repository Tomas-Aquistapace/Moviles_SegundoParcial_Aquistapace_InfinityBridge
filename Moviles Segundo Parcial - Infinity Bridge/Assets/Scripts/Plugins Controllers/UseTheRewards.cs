using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTheRewards : MonoBehaviour
{

    public void ShowAchievements()
    {
        Audio_Manager.instance.Play("Click");

        PlayGames.ShowAchievements();
    }
    
    public void ShowLeaderboard()
    {
        Audio_Manager.instance.Play("Click");

        PlayGames.ShowLeaderboard();
    }

}
