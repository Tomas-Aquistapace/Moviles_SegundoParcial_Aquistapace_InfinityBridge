using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Bridge" && other.GetComponent<PieceController>().bridgeState == PieceController.State.Locked)
        {
            this.gameObject.SetActive(false);
        }
    }
}
