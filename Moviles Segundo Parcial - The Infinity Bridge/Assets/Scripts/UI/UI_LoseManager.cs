using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LoseManager : MonoBehaviour
{
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject pauseButton;

    private void OnEnable()
    {
        PlayerState.LoseGame += EnableDeathBox;
    }

    private void OnDisable()
    {
        PlayerState.LoseGame -= EnableDeathBox;
    }

    void EnableDeathBox()
    {
        loseScreen.SetActive(true);
        pauseButton.SetActive(false);
    }

}
