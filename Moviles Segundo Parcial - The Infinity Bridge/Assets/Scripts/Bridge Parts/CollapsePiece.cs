using UnityEngine;

public class CollapsePiece : MonoBehaviour
{

    public void Collapse()
    {
        this.transform.parent.gameObject.SetActive(false);
    }

}
