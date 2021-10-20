using UnityEngine;

public abstract class TypeOfInput
{
    public float scale = 0f;

    public void Setscale(float value)
    {
        scale = value;
    }

    public abstract void UpdateInput();

    public void RotateObject(Vector3 angle)
    {
        Vector3 rotation = PointerManager.GetObjSelected().transform.rotation.eulerAngles;
        rotation += angle;
        PointerManager.GetObjSelected().transform.rotation = Quaternion.Euler(rotation);
    }
}


// ======================================


public class MobileInput : TypeOfInput
{
    public MobileInput(float value)
    {
        Setscale(value);
    }

    public override void UpdateInput()
    {
        if (Input.touchCount == 2)
        {
            Touch touch = Input.GetTouch(1);

            if (touch.phase == TouchPhase.Moved)
            {
                RotateObject(new Vector3(0, touch.deltaPosition.y * Time.deltaTime * scale, touch.deltaPosition.x * Time.deltaTime * scale));
            }
        }
    }
}

public class PcInput : TypeOfInput
{
    public PcInput(float value)
    {
        Setscale(value);
    }

    public override void UpdateInput()
    {
        if (Input.GetMouseButton(1) && Input.mouseScrollDelta.y != 0 && PointerManager.GetObjSelected() != null)
        {
            RotateObject(new Vector3(0, 0, Input.mouseScrollDelta.y * scale));
        }
        else if (Input.mouseScrollDelta.y != 0 && PointerManager.GetObjSelected() != null)
        {
            RotateObject(new Vector3(0, Input.mouseScrollDelta.y * scale, 0));
        }
    }
}
