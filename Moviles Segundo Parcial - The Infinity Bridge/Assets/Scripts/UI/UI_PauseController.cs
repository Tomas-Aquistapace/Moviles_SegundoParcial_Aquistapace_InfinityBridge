﻿using UnityEngine;

public class UI_PauseController : MonoBehaviour
{
    [SerializeField] GameObject pauseLayer;
    [SerializeField] GameObject pauseButton;

    public void StartPause()
    {
        AudioManager.instance.Play("Click");

        Time.timeScale = 0f;

        pauseLayer.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ClosePause()
    {
        AudioManager.instance.Play("Click");

        Time.timeScale = 1f;

        pauseLayer.SetActive(false);
        pauseButton.SetActive(true);
    }

}
