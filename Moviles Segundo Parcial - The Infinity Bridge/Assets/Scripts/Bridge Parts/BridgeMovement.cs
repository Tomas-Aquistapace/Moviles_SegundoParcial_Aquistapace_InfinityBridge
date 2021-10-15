using UnityEngine;

public class BridgeMovement : MonoBehaviour
{
    [Header("Initial Piece")]
    [SerializeField] bool initialPiece = false;
    [SerializeField] float deactivatePosZ = 0;

    private void Update()
    {
        MoveBridge();
    }

    void MoveBridge()
    {
        Vector3 newDirection = -Vector3.forward * Time.deltaTime * GameManager.GetSpeed();//speedMovement;
        this.transform.position += newDirection;

        if(initialPiece && this.transform.position.z < deactivatePosZ)
        {
            this.gameObject.SetActive(false);
        }
    }
}
