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

    public BoxCollider bridgePosColl;

    // =======================
    
    private Vector3 mOffset;
    private float mZCoord;

    // =======================

    private void OnMouseDown()
    {
        if (bridgeState == State.Avaible)
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();

            PointerManager.SetObjSelected(this.gameObject);

            bridgeState = State.Moving;
        }
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

            other.GetComponent<BoxCollider>().enabled = false;
            bridgePosColl.enabled = true;
        }
    }

    public void ResetState(Vector3 newPos)
    {
        bridgeState = State.Avaible;

        Vector3 newRotation = new Vector3(0, Random.Range(0, 360), 0);        
        this.transform.rotation = Quaternion.Euler(newRotation);

        this.transform.position = newPos;
    }

}