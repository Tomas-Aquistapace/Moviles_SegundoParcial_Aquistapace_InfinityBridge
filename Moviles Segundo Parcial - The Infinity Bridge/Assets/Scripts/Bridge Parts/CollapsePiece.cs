using UnityEngine;

public class CollapsePiece : MonoBehaviour
{
    
    public void Collapse()
    {
        Destroy(this.transform.parent.gameObject);
    }

}
