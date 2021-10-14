using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float bridgeSpeed = 1.5f;

    public static float speed = 1.5f;

    // ===========================

    private void Awake()
    {
        speed = bridgeSpeed;
    }

    private void OnEnable()
    {
        PlayerState.LoseGame += StopSpeed;
    }

    private void OnDisable()
    {
        PlayerState.LoseGame -= StopSpeed;
    }

    public static float GetSpeed()
    {
        return speed;
    }

    public void StopSpeed()
    {
        speed = 0f;
    }
}