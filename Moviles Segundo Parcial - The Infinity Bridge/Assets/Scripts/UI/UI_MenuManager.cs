using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MenuManager : MonoBehaviour
{
    public void GoToSceneLoading(string scene)
    {
        Audio_Manager.instance.Play("Click");

        ScenesLoaderHandler.LoadScene(scene);
    }

    public void RestartScene()
    {
        Audio_Manager.instance.Play("Click");

        string scene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(scene);
    }

    public void GoToSceneWithoutLoading(string scene)
    {
        Audio_Manager.instance.Play("Click");

        SceneManager.LoadScene(scene);

        Audio_Manager.instance.Stop("Gameplay");
    }

    public void ExitGame()
    {
        Audio_Manager.instance.Play("Click");

        Application.Quit();
    }
}
