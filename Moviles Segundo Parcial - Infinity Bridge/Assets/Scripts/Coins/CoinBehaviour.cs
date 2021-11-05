using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{

    [SerializeField] private float speed = 2f;

    void Update()
    {

        this.transform.Rotate(0, speed, 0);

    }
}
