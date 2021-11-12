using UnityEngine;

public class LoadSkinAssets : MonoBehaviour
{
    [SerializeField] private string path = "Skins/";
    [SerializeField] private string file = "_Skin";

    public static Mesh skinMesh;

    private GameObject prefSkin;

    public void Awake()
    {
        string name = "empty";

        name = LoadData.GetActualSkin() + file;

        Object pref = Resources.Load((path + name), typeof(GameObject));
        prefSkin = (GameObject)pref;

        skinMesh = prefSkin.GetComponent<MeshFilter>().sharedMesh;
    }

    public static Mesh GetSkin()
    {
        return skinMesh;
    }
}
