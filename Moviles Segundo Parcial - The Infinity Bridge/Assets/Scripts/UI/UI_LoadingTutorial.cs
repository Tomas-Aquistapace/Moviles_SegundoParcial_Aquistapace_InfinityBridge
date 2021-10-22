using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_LoadingTutorial : MonoBehaviour
{
    [Header("Fingers: ")]
    [SerializeField] private GameObject[] fingers = new GameObject[3];

    [Header("Sprites: ")]
    [SerializeField] private Sprite fingerImg;
    [SerializeField] private Sprite[] mouseImg;

    [Header("Texts: ")]
    [SerializeField] TextMeshProUGUI moveTutorial;    
    [SerializeField] TextMeshProUGUI rotateTutorial;

    [SerializeField] [TextArea] private string mobileMoveText;
    [SerializeField] [TextArea] private string mobileRotateText;

    [SerializeField] [TextArea] private string mobilePcText;
    [SerializeField] [TextArea] private string rotatePcText;

    private void Awake()
    {
#if UNITY_EDITOR || UNITY_STANDALONE

        moveTutorial.text = mobilePcText;
        rotateTutorial.text = rotatePcText;

        for (int i = 0; i < fingers.Length; i++)
        {
            fingers[i].GetComponent<Image>().sprite = mouseImg[i];
        }

#elif UNITY_ANDROID || UNITY_IOS
        
        moveTutorial.text = mobileMoveText;
        rotateTutorial.text = mobileRotateText;

        for (int i = 0; i < fingers.Length; i++)
        {
            fingers[i].GetComponent<Image>().sprite = fingerImg;
        }
        
#endif
    }
}
