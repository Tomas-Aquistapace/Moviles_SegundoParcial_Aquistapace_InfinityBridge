using UnityEngine;

public class InvisibleObjects : MonoBehaviour
{
    [SerializeField] float radius = 1f;
    [SerializeField] Color color = Color.blue;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        
        Gizmos.DrawSphere(this.transform.position, radius);
    }
}
