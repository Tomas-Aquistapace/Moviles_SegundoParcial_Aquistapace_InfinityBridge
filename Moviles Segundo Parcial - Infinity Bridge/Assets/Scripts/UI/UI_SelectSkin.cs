using UnityEngine.UI;
using UnityEngine;

public class UI_SelectSkin : MonoBehaviour
{
    [Header("Player")]
    public GameObject prefPlayer;

    [Header("Menu")]
    public MeshFilter menuPlayer;

    [Header("Skins")]
    public int skinSelected;
    public int skinValue = 10;
    public Mesh skin;
    
    [Header("Buttons")]
    public Sprite lockedSkins;
    public Sprite unlockedSkins;
    public bool unlockableSkin_State = false;

    [Header("Arrow")]
    public Transform arrow;
    public Vector2 pos;

    private void Start()
    {
        unlockableSkin_State = LoadData.GetSkinState(skinSelected);

        // Check State:

        if (unlockableSkin_State)
        {
            this.transform.GetComponent<Button>().image.sprite = unlockedSkins;
        }
        else
        {
            this.transform.GetComponent<Button>().image.sprite = lockedSkins;
        }

        // Check Arrow Pos:

        if(skinSelected == LoadData.GetActualSkin())
        {
            prefPlayer.transform.GetComponent<PlayerState>().meshFilter.mesh = skin;

            menuPlayer.mesh = skin;

            arrow.transform.localPosition = pos;

            LoadData.SaveData();
        }
    }

    public void UnlockSkin()
    {
        if (unlockableSkin_State == false)
        {
            if (LoadData.GetActualCoins() >= skinValue)
            {
                Audio_Manager.instance.Play("UnlockSkin");

                LoadData.SetActualCoins(skinValue);

                unlockableSkin_State = true;

                LoadData.SetSkinState(skinSelected, unlockableSkin_State);

                this.transform.GetComponent<Button>().image.sprite = unlockedSkins;

#if UNITY_ANDROID
                PlayGames.UnlockAchievement(skinSelected);
#endif
            }
            else
            {
                Audio_Manager.instance.Play("LockedSkin");
            }
        }
        else
        {
            Audio_Manager.instance.Play("Click");

            prefPlayer.transform.GetComponent<PlayerState>().meshFilter.mesh = skin;

            menuPlayer.mesh = skin;

            LoadData.SetActualSkin(skinSelected);

            arrow.transform.localPosition = pos;
        }

        LoadData.SaveData();
    }
}