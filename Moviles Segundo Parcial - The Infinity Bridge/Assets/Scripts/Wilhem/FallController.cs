using UnityEngine;

public class FallController : MonoBehaviour
{
    [SerializeField] float distanceRay = 1f;
    [SerializeField] LayerMask layerMask;

    [SerializeField] Animator anim;

    // =======================

    private PlayerState playerSate;

    // =======================

    private void Awake()
    {
        playerSate = GetComponent<PlayerState>();
    }

    private void OnEnable()
    {
        PlayerState.LoseGame += LoseAction;
    }

    private void OnDisable()
    {
        PlayerState.LoseGame -= LoseAction;
    }

    private void Update()
    {
        FloorDistance();
    }

    // =======================

    void FloorDistance()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distanceRay, layerMask) == false)
        {
            playerSate.SetState(PlayerState.State.Lose);
            LoseAction();
            anim.SetTrigger("Fall");
        }
    }

    public void LoseAction()
    {

    }

    // =======================

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - distanceRay, transform.position.z));
    }

}
