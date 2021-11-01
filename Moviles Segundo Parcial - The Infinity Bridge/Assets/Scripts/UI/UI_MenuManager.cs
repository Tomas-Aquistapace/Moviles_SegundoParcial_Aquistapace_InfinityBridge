using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MenuManager : MonoBehaviour
{
    public void GoToSceneLoading(string scene)
    {
        AudioManager.instance.Play("Click");

        ScenesLoaderHandler.LoadScene(scene);
    }

    public void RestartScene()
    {
        AudioManager.instance.Play("Click");

        string scene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(scene);
    }

    public void GoToSceneWithoutLoading(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        AudioManager.instance.Play("Click");

        Application.Quit();
    }
}
