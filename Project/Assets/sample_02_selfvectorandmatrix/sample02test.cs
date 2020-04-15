using UnityEngine;
using VecAndMtr;
using Vector3 = VecAndMtr.Vector3;

public class sample02test : MonoBehaviour
{
    public LineRenderer u;
    public LineRenderer v;
    public LineRenderer w;
    // Start is called before the first frame update
    void Start()
    {
        //点乘测试
        Debug.Log("me dot" + Vector3.Dot(new Vector3(1, 2, 3), new Vector3(1, 2, 3)));
        Debug.Log("unity dot" + UnityEngine.Vector3.Dot(new UnityEngine.Vector3(1, 2, 3), new UnityEngine.Vector3(1, 2, 3)));
        //点乘测试
        Debug.Log("me cross" + Vector3.Cross(new Vector3(1, 2, 3), new Vector3(4, 5, 6)).ToString());
        Debug.Log("unity cross" + UnityEngine.Vector3.Cross(new UnityEngine.Vector3(1, 2, 3), new UnityEngine.Vector3(4, 5, 6)));
        u.SetPositions(new UnityEngine.Vector3[] { new UnityEngine.Vector3(0, 0, 0), new UnityEngine.Vector3(1, 2, 3) });
        v.SetPositions(new UnityEngine.Vector3[] { new UnityEngine.Vector3(0, 0, 0), new UnityEngine.Vector3(-2, 3.5f, 7) });
        w.SetPositions(new UnityEngine.Vector3[] { new UnityEngine.Vector3(0, 0, 0), UnityEngine.Vector3.Cross(new UnityEngine.Vector3(1, 2, 3), new UnityEngine.Vector3(-2, 3.5f, 7)) });
        Matrix4x4
    }

}
