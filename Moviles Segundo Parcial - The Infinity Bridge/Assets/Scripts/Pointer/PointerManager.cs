using UnityEngine;

public class PointerManager : MonoBehaviour
{
    [SerializeField] Vector3 offsetArrowVar;
    [SerializeField] GameObject arrowDownVar;

    private static Vector3 offsetArrow;
    private static GameObject arrowDown;

    [SerializeField] static GameObject selected;

    private void Awake()
    {
        selected = null;

        offsetArrow = offsetArrowVar;
        arrowDown = arrowDownVar;
    }

    public static GameObject GetObjSelected()
    {
        return selected;
    }

    public static void SetObjSelected(GameObject obj)
    {
        selected = obj;
    }

    private void Update()
    {
        if(selected)
            arrowDown.transform.position = selected.transform.position + offsetArrow;
    }
}
