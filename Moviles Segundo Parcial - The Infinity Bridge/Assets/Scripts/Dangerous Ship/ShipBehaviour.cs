using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private bool isAlive = true;
    private Animator animator;
    private Collider coll;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider>();
    }

    private void Update()
    {
        MoveShip();
    }

    private void OnMouseDown()
    {
        DisableShip();
    }

    void MoveShip()
    {
        if (isAlive)
        {
            Vector3 newDirection = -Vector3.right * Time.deltaTime * GameManager.GetReleaseSpeed() * speed;
            this.transform.position += newDirection;
        }
    }

    public void DisableShip()
    {
        if(isAlive)
        {
            animator.SetTrigger("Sink");

            isAlive = false;

            coll.enabled = false;
        }
    }

    public void DestroyShip()
    {
        Destroy(this.gameObject);
    }
}
