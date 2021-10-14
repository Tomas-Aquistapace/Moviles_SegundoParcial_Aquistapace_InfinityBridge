using UnityEngine;

public class UI_PauseController : MonoBehaviour
{
    [SerializeField] GameObject pauseLayer;
    [SerializeField] GameObject pauseButton;

    public void StartPause()
    {
        Time.timeScale = 0f;

        pauseLayer.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ClosePause()
    {
        Time.timeScale = 1f;

        pauseLayer.SetActive(false);
        pauseButton.SetActive(true);
    }

}
