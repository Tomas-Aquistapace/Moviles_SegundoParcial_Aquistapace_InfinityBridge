using UnityEngine;

public class BridgeMovement : MonoBehaviour
{
    [SerializeField] float speedMovement = 3f;

    private void Update()
    {
        MoveBridge();
    }

    void MoveBridge()
    {
        Vector3 newDirection = -Vector3.forward * Time.deltaTime * speedMovement;

        this.transform.position += newDirection;
    }
}
