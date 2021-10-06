using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParallax : MonoBehaviour
{
    [SerializeField] Transform water1;
    [SerializeField] Transform water2;

    [SerializeField] float speedMovement = 3f;

    Vector3 initPositionW1;
    Vector3 initPositionW2;

    private void Start()
    {
        initPositionW1 = water1.position;
        initPositionW2 = water2.position;
    }

    private void Update()
    {
        Vector3 newDirection = -Vector3.forward * Time.deltaTime * speedMovement;

        water1.position += newDirection;
        water2.position += newDirection;


        if (water1.position.z <= -initPositionW2.z)
        {
            water1.position = initPositionW2;
            Debug.Log(water2.position);
        }
        if (water2.position.z <= -initPositionW2.z)
        {
            water2.position = initPositionW2;
        }
    }
}
