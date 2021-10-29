using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CallLayer : MonoBehaviour
{
    [SerializeField] private Transform[] layer;

    public void CallLayer(int i)
    {
        layer[i].GetComponent<Animator>().SetBool("Call", false);
    }

    public void CloseLayer(int i)
    {
        layer[i].GetComponent<Animator>().SetBool("Call", true);
    }

}