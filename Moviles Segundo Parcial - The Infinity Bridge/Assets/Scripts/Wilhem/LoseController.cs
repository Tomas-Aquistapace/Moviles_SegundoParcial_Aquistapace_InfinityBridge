using UnityEngine;

public class LoseController : MonoBehaviour
{
    [SerializeField] float distanceRay = 1f;
    [SerializeField] Vector3 rayPos;
    [SerializeField] LayerMask layerMask;

    [SerializeField] Animator anim;

    public int lives = 3;

    public bool ableToReceive = true;
    
    // =======================

    private PlayerState playerState;

    private Transform pieceTrans = null; // Used for the points

    // =======================

    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
    }

    private void Update()
    {
        FloorDistance();
    }

    // =======================

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "DangerZone")
        {
            if (ableToReceive)
            {
                lives--;

                ableToReceive = false;

                playerState.UpdateLives(lives);

                if (lives <= 0)
                {
                    playerState.SetState(PlayerState.State.Lose);
                    anim.SetTrigger("TripOn");
                }
                else
                {
                    anim.SetTrigger("TakeDamage");
                }
            }
        }
    }

    void FloorDistance()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position - rayPos, Vector3.down - rayPos, out hit, distanceRay, layerMask) == false)
        {
            LoseAction();
        }
        else if(hit.transform.tag == "BridgePiece")
        {
            if(pieceTrans != hit.transform)
            {
                pieceTrans = hit.transform;

                playerState.WinPoints();
            }
        }
    }

    void LoseAction()
    {
        if(lives > 0)
        {
            lives = 0;
            playerState.UpdateLives(lives);
            
            playerState.SetState(PlayerState.State.Lose);
            anim.SetTrigger("Fall");
        }
    }

    public void AbleToReceiveDamage()
    {
        ableToReceive = true;
    }

    // =======================

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(transform.position - rayPos, new Vector3(transform.position.x, transform.position.y - distanceRay, transform.position.z) - rayPos);
    }

}
