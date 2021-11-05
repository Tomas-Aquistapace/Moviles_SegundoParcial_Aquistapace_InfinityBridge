using UnityEngine;

public class MakeSomeNoise : MonoBehaviour
{
    [SerializeField] float power = 3;
    [SerializeField] float scale = 1;
    [SerializeField] float timeScale = 1;

    private float xOffSet;
    private float yOffSet;
    private MeshFilter mf;

    private void Start()
    {
        mf = GetComponent<MeshFilter>();
        MakeNoise();
    }

    private void Update()
    {
        MakeNoise();
        xOffSet += Time.deltaTime * timeScale;
        yOffSet += Time.deltaTime * timeScale;
    }

    void MakeNoise()
    {
        Vector3[] verticies = mf.mesh.vertices;

        for (int i = 0; i < verticies.Length; i++)
        {
            verticies[i].y = CalculateHeigth(verticies[i].x, verticies[i].z * power);
        }

        mf.mesh.vertices = verticies;
    }

    float CalculateHeigth(float x, float y)
    {

        float xCord = x * scale + xOffSet;
        float yCord = y * scale + yOffSet;

        return Mathf.PerlinNoise(xCord, yCord);
    }
}
