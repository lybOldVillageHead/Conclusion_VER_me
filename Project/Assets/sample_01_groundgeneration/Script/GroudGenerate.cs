using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroudGenerate : MonoBehaviour
{
    public float VertsWidth = 0.1f;
    public float VertsHeight = 5f;
    [Range(0, 1)]
    public float NoiseParam = .1f;
    public float NoiseOffsetX = 0f;
    public float NoiseOffsetZ = 0f;
    [Range(1,256)]
    public int MartixOrder = 100;

    public Texture2D HeightMap;

    //mesh组件 
    MeshRenderer meshRenderer;
    MeshFilter meshFilter;
    MeshCollider meshCollider;

    // 用来存放顶点数据
    List<Vector3> verts;
    List<int> vertsIndices;

    private void Start()
    {
        verts = new List<Vector3>();
        vertsIndices = new List<int>();

        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();

        Generate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Generate();
        }
    }


    public void Generate()
    {
        ClearMeshData();

        // 把数据填写好
        AddMeshData();

        // 把数据传递给Mesh，生成真正的网格
        Mesh mesh = new Mesh
        {
            vertices = verts.ToArray(),
            triangles = vertsIndices.ToArray()
        };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        meshFilter.mesh = mesh;

        // 碰撞体专用的mesh，只负责物体的碰撞外形
        meshCollider.sharedMesh = mesh;
    }

    private void ClearMeshData()
    {
        verts.Clear();
        vertsIndices.Clear();
    }

    private void AddMeshData()
    {
        Color32[] colors=null;
        int pixelCount = 0;

        if (HeightMap != null)
        {
            colors = HeightMap.GetPixels32();
            pixelCount = HeightMap.height;
        }
        //添加顶点
        for (int rowIndex = 0; rowIndex < MartixOrder; rowIndex++)//外层按行扫描 行(Z)坐标
        {
            for (int colIndex = 0; colIndex < MartixOrder; colIndex++)//内层按列扫描 列(X)坐标
            {
                if (HeightMap != null)
                {
                    float x = ((colIndex * 1f) / MartixOrder) * pixelCount;
                    float z = ((rowIndex * 1f) / MartixOrder) * pixelCount;
                    float y = (colors[Mathf.RoundToInt(z) * pixelCount + Mathf.RoundToInt(x)].r / 255f) * VertsHeight;
                    Vector3 p = new Vector3(x, y, z) * VertsWidth;
                    verts.Add(p);
                }
                else {
                    float random = Random.Range(0f, 1f);
                    float x = colIndex;
                    float z = rowIndex;
                    float y = Mathf.PerlinNoise((x + NoiseOffsetX) * NoiseParam, (z + NoiseOffsetZ) * NoiseParam) * VertsHeight;
                    Vector3 p = new Vector3(x, y, z) * VertsWidth;
                    verts.Add(p);
                }
            }

        }

        //绘制三角形
        for (int rowIndex = 0; rowIndex < MartixOrder - 1; rowIndex++)//外层按行扫描 行(Z)坐标
        {
            for (int colIndex = 0; colIndex < MartixOrder - 1; colIndex++)//内层按列扫描 列(X)坐标
            {
                int p1 = rowIndex + colIndex * MartixOrder;//当前点
                int p2 = rowIndex + (colIndex + 1) * MartixOrder;//上
                int p3 = (rowIndex + 1) + (colIndex + 1) * MartixOrder;//右上
                int p4 = (rowIndex + 1) + colIndex * MartixOrder; ;//后边
                //添加上半三角形
                vertsIndices.Add(p1);
                vertsIndices.Add(p2);
                vertsIndices.Add(p3);
                //添加下半三角形
                vertsIndices.Add(p1);
                vertsIndices.Add(p3);
                vertsIndices.Add(p4);

            }

        }

    }

}

