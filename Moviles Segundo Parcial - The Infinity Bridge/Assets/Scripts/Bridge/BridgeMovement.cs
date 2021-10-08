using UnityEngine;

public class BridgeMovement : MonoBehaviour
{
    [Header("Initial Piece")]
    [SerializeField] bool initialPiece = false;
    [SerializeField] float deactivatePosZ = 0;
    
    [Header("Normal Piece")]
    [SerializeField] float speedMovement = 3f;

    private void Update()
    {
        MoveBridge();
    }

    void MoveBridge()
    {
        Vector3 newDirection = -Vector3.forward * Time.deltaTime * speedMovement;
        this.transform.position += newDirection;

        if(initialPiece && this.transform.position.z < deactivatePosZ)
        {
            this.gameObject.SetActive(false);
        }
    }
}
