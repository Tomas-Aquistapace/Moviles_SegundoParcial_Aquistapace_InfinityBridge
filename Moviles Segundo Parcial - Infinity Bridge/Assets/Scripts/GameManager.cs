using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float bridgeLockedSpeed = 1.2f;
    [SerializeField] float bridgeReleaseSpeed = 1.5f;

    public static float lockedSpeed = 1.2f;
    public static float releaseSpeed = 1.5f;

    // ===========================

    private void Awake()
    {
        releaseSpeed = bridgeReleaseSpeed;
        lockedSpeed = bridgeLockedSpeed;
    }

    private void OnEnable()
    {
        PlayerState.LoseGame += StopSpeed;
    }

    private void OnDisable()
    {
        PlayerState.LoseGame -= StopSpeed;
    }

    private void Start()
    {
        Audio_Manager.instance.Stop("Menu");

        Audio_Manager.instance.Play("Gameplay");
    }

    public static float GetReleaseSpeed()
    {
        return releaseSpeed;
    }
    
    public static float GetLockedSpeed()
    {
        return lockedSpeed;
    }

    public void StopSpeed()
    {
        releaseSpeed = 0f;
        lockedSpeed = 0f;
    }
}