using System.Collections;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    public enum State
    {
        Avaible,
        Moving,
        Locked,
        Collapse
    };
    public State bridgeState = State.Avaible;

    [SerializeField] private GameObject constructionZone;
    [SerializeField] private GameObject body;

    [SerializeField] private Animator animator;

    [SerializeField] private float rotationSpeed = 5f;

    [SerializeField] private float timeToUnlock = 1f;

    [SerializeField] private GameObject[] obstacles;
    private int lastObstacle = -1;

    // =======================
    
    private Vector3 mOffset;
    private float mZCoord;

    private bool ableToRotate = true;

    private GameObject constructionZoneRef;

    private float time = 0f;

    // =======================

    private void Start()
    {
        constructionZone.SetActive(false);

        ableToRotate = true;

        time = 0f;
    }

    private void OnDisable()
    {
        animator.SetBool("Connected", false);

        GetComponent<Collider>().enabled = true;

        bridgeState = State.Avaible;

        body.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void OnMouseDown()
    {
        if (bridgeState == State.Avaible)
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();

            bridgeState = State.Moving;

            animator.SetBool("Connected", true);
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
        else if (bridgeState == State.Locked)
        {
            if(time > timeToUnlock)
            {
                mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                mOffset = gameObject.transform.position - GetMouseWorldPos();

                bridgeState = State.Moving;

                animator.SetBool("Connected", false);

                constructionZoneRef.SetActive(true);
                constructionZone.SetActive(false);

                time = 0f;
            }
            else
            {
                time += Time.deltaTime;
            }            
        }
    }

    private void OnMouseUp()
    {
        if(bridgeState == State.Moving)
        {
            bridgeState = State.Avaible;
            animator.SetBool("Connected", false);
        }
    }

    // =======================

    private void OnTriggerEnter(Collider other) // Si colisiono con un barco
    {
        if(other.transform.tag == "DangerousShip")
        {
            if(other.GetComponent<ShipBehaviour>())
                other.GetComponent<ShipBehaviour>().DisableShip();

            // ----

            Collider col = GetComponent<Collider>();
            col.enabled = false;

            Audio_Manager.instance.Play("Collapse");

            animator.SetTrigger("Collapse");
            bridgeState = State.Collapse;

            if(PointerManager.GetObjSelected() == this.transform)
                PointerManager.SetObjSelected(null);

            if(constructionZoneRef)
                constructionZoneRef.SetActive(true);

            constructionZone.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other) // Si colisiono con una zona de construccion
    {        
        if(other.transform.tag == "BridgePos" && bridgeState == State.Avaible)
        {
            transform.position = other.transform.position;

            bridgeState = State.Locked;

            other.GetComponent<Transform>().gameObject.SetActive(false);
            constructionZone.SetActive(true);

            constructionZoneRef = other.GetComponent<Transform>().gameObject;

            animator.SetBool("Connected", true);
        }
    }

    public void ResetState(Vector3 newPos)
    {
        animator.SetBool("Connected", false);

        GetComponent<Collider>().enabled = true;

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