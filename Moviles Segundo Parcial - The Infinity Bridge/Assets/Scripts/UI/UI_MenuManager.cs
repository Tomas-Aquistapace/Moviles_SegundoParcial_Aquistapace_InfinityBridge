using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MenuManager : MonoBehaviour
{
    public void GoToSceneLoading(string scene)
    {
        ScenesLoaderHandler.LoadScene(scene);
    }

    public void RestartScene()
    {
        string scene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(scene);
    }

    public void GoToSceneWithoutLoading(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
