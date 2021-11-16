using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;


public class PlayGames : MonoBehaviour
{
    public int playerScore;
    string leaderboardID = "";

    static string[] achievementID = new string[3];

    public static PlayGamesPlatform platform;

    void Start()
    {
        achievementID[0] = GPGSIds.achievement_you_are_finally_awake;
        achievementID[1] = GPGSIds.achievement_jump_little_frog;
        achievementID[2] = GPGSIds.achievement_white_like_bones;

        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            platform = PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate(success =>
        {
            if (success)
            {
                Debug.Log("Logged in successfully");
            }
            else
            {
                Debug.Log("Login Failed");
            }
        });

        UnlockAchievement(0);
    }

    public void AddScoreToLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportScore(playerScore, leaderboardID, success => { });
        }
    }

    public void ShowLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowLeaderboardUI();
        }
    }

    public void ShowAchievements()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowAchievementsUI();
        }
    }

    public static void UnlockAchievement(int ID)
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(achievementID[ID], 100f, success => { });
        }
    }
}