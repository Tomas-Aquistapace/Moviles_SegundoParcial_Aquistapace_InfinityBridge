﻿using System.Collections;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    public enum State
    {
        Avaible,
        Moving,
        Locked
    };
    public State bridgeState = State.Avaible;

    [SerializeField] private GameObject constructionZone;
    [SerializeField] private GameObject body;

    [SerializeField] private float rotationSpeed = 5f;

    [SerializeField] private GameObject[] obstacles;
    private int lastObstacle = -1;

    // =======================
    
    private Vector3 mOffset;
    private float mZCoord;

    private bool ableToRotate = true;

    // =======================

    private void Start()
    {
        constructionZone.SetActive(false);

        ableToRotate = true;
    }

    private void OnMouseDown()
    {
        if (bridgeState == State.Avaible)
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();

            bridgeState = State.Moving;
        }

        PointerManager.SetObjSelected(this.transform);
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if (bridgeState == State.Moving)
        {
            Vector3 newPos = GetMouseWorldPos() + mOffset;
            newPos.y = 0;
            transform.position = newPos;
        }
    }

    private void OnMouseUp()
    {
        if(bridgeState == State.Moving)
            bridgeState = State.Avaible;
    }

    // =======================

    private void OnTriggerStay(Collider other)
    {        
        if(other.transform.tag == "BridgePos" && bridgeState == State.Avaible)
        {
            transform.position = other.transform.position;

            bridgeState = State.Locked;

            other.GetComponent<Transform>().gameObject.SetActive(false);
            constructionZone.SetActive(true);
        }
    }

    public void ResetState(Vector3 newPos)
    {
        SelectANewObstacle();

        bridgeState = State.Avaible;

        int posY = Random.Range(0, 4) * 90;
        
        Vector3 newRotation = new Vector3(0, posY, 0);
        body.transform.rotation = Quaternion.Euler(newRotation);

        this.transform.position = newPos;
    }

    public void RotateObject(Vector3 newPos)
    {
        if (ableToRotate)
        {
            StartCoroutine(RotationLerp(newPos));
        }
    }

    // =======================

    void SelectANewObstacle()
    {
        if (lastObstacle >= 0)
            obstacles[lastObstacle].SetActive(false);

        int num = Random.Range(0, obstacles.Length);

        obstacles[num].SetActive(true);
        lastObstacle = num;
    }

    IEnumerator RotationLerp(Vector3 newPos)
    {
        float time = 0f;

        Quaternion from = body.transform.rotation;
        Quaternion to = from * Quaternion.Euler(newPos);

        ableToRotate = false;

        while (time < 1)
        {
            time += rotationSpeed * Time.deltaTime;

            body.transform.rotation = Quaternion.Slerp(from, to, time);
            
            yield return null;
        }

        ableToRotate = true;
    }
}