using UnityEngine;

public class PointerManager : MonoBehaviour
{
    [SerializeField] Vector3 offsetArrowVar;
    [SerializeField] GameObject arrowDownVar;

    private static Vector3 offsetArrow;
    private static GameObject arrowDown;

    [SerializeField] static Transform selected;

    private void Awake()
    {
        selected = null;

        offsetArrow = offsetArrowVar;
        arrowDown = arrowDownVar;
    }

    public static Transform GetObjSelected()
    {
        return selected;
    }

    public static void SetObjSelected(Transform obj)
    {
        selected = obj;
    }

    private void Update()
    {
        if(selected)
            arrowDown.transform.position = selected.position + offsetArrow;
    }
}
