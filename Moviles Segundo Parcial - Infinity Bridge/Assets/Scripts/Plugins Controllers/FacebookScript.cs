using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Facebook.Unity;

public class FacebookScript : MonoBehaviour
{
    public TextMeshProUGUI PlayerFacebookName;

    public string LoggedIn = "You are Connected!";
    public string LoggedOut = "You are not Connected...";

    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();
                else
                    Debug.LogError("Couldn't initialize");
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            });
        }
        else
            FB.ActivateApp();
    }

    private void Update()
    {
        PlayerFacebookName.text = IsLogged();
    }

    #region Login / Logout
    public void FacebookLogin()
    {
        var permissions = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(permissions);
    }

    public void FacebookLogout()
    {
        FB.LogOut();
    }
    #endregion

    public void FacebookShare()
    {
        FB.ShareLink(new System.Uri("https://tomasaquistapace.itch.io/"), "Check it out!",
            "Good programming tutorials lol!",
            new System.Uri("https://user-images.githubusercontent.com/7604468/87527283-e4b9eb00-c659-11ea-8281-dc9d8377ce30.png"));
    }

    #region Inviting
    public void FacebookGameRequest()
    {
        FB.AppRequest("Hey! Come and play this awesome game!", title: "Reso Coder Tutorial");
    }
    #endregion

    string IsLogged()
    {
        if (FB.IsLoggedIn)
        {
            return LoggedIn;
        }
        else
        {
            return LoggedOut;
        }
    }
}