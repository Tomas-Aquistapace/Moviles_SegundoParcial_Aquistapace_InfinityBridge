using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] float scale = 10f;

    TypeOfInput input;

    public void Awake()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        input = new PcInput(scale);
#elif UNITY_ANDROID || UNITY_IOS
        input = new MobileInput(scale);
#endif
    }

    private void Update()
    {
        input.UpdateInput();
    }
}