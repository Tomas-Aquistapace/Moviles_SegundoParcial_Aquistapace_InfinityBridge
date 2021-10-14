using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerManager : MonoBehaviour
{

    [SerializeField] static GameObject selected;

    private void Awake()
    {
        selected = null;
    }

    public static GameObject GetObjSelected()
    {
        return selected;
    }

    public static void SetObjSelected(GameObject obj)
    {
        selected = obj;
    }

}
