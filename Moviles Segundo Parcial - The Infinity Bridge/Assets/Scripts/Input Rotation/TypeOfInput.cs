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
        PointerManager.GetObjSelected().GetComponent<PieceController>().RotateObject(rotation);
    }
}


// ======================================


public class MobileInput : TypeOfInput
{
    private const float DOUBLE_TAP_TIME = 0.2f;
    private float lastTapTime = 0f;

    public MobileInput(float value)
    {
        Setscale(value);
    }

    public override void UpdateInput()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float timeSinceLastTap = Time.time - lastTapTime;

            if (timeSinceLastTap <= DOUBLE_TAP_TIME)
            {
                RotateObject(new Vector3(0, scale, 0));
            }

            lastTapTime = Time.time;
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
        if (Input.GetMouseButtonDown(1) && PointerManager.GetObjSelected() != null)
        {
            RotateObject(new Vector3(0, scale, 0));
        }
    }
}