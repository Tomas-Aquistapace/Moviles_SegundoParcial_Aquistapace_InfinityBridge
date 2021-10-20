using UnityEngine;

public class BridgeMovement : MonoBehaviour
{
    [Header("Initial Piece")]
    [SerializeField] bool initialPiece = false;
    [SerializeField] float deactivatePosZ = 0;

    private PieceController pieceController;

    private void Awake()
    {
        if(GetComponent<PieceController>())
            pieceController = GetComponent<PieceController>();
    }

    private void Update()
    {
        MoveBridge();
    }

    void MoveBridge()
    {
        if (GetComponent<PieceController>())
        {
            if (pieceController.bridgeState == PieceController.State.Avaible)
            {
                Vector3 newDirection = -Vector3.forward * Time.deltaTime * GameManager.GetReleaseSpeed();
                this.transform.position += newDirection;
            }
            else if (pieceController.bridgeState == PieceController.State.Locked)
            {
                Vector3 newDirection = -Vector3.forward * Time.deltaTime * GameManager.GetLockedSpeed();
                this.transform.position += newDirection;
            }
        }
        else
        {
            Vector3 newDirection = -Vector3.forward * Time.deltaTime * GameManager.GetLockedSpeed();
            this.transform.position += newDirection;
        }

        if(initialPiece && this.transform.position.z < deactivatePosZ)
        {
            this.gameObject.SetActive(false);
        }
    }
}
