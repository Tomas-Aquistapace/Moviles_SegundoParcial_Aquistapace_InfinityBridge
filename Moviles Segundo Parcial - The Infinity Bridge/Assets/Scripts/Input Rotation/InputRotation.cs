using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRotation : MonoBehaviour
{
    [SerializeField] float scale = 10f;

    private void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
#if UNITY_EDITOR
        if (Input.mouseScrollDelta.y != 0 && PointerManager.GetObjSelected() != null)
        {
            Vector3 rotation = PointerManager.GetObjSelected().transform.rotation.eulerAngles;

            rotation += new Vector3(0, Input.mouseScrollDelta.y * scale, 0);
            
            PointerManager.GetObjSelected().transform.rotation = Quaternion.Euler(rotation);
        }
#elif UNITY_ANDROID || UNITY_IOS

#else

#endif
    }




}
