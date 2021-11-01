using UnityEngine;

public class UI_CallLayer : MonoBehaviour
{
    [SerializeField] private Transform[] layer;

    public void CallLayer(int i)
    {
        Audio_Manager.instance.Play("Click");

        layer[i].GetComponent<Animator>().SetBool("Call", false);
    }

    public void CloseLayer(int i)
    {
        Audio_Manager.instance.Play("Click");

        layer[i].GetComponent<Animator>().SetBool("Call", true);
    }

}