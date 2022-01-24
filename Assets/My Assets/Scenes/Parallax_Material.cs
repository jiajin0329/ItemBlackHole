using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Material : MonoBehaviour
{
    /// <summary>
    /// 距離
    /// </summary>
    [Header("距離")]
    [SerializeField]
    private ushort dis;

    private Transform tm;

    /// <summary>
    /// 開始座標
    /// </summary>
    private Vector2 start_pos;

    /// <summary>
    /// 目標
    /// </summary>
    [Header("目標")]
    [SerializeField]
    private Transform target;
    
    private Renderer rd;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
        dis = (ushort)(transform.position.z);
        tm = transform;
        start_pos = tm.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 sum = new Vector2(target.position.x, target.position.y) - start_pos;
        rd.material.SetTextureOffset("_MainTex", start_pos - new Vector2(sum.x, sum.y) * dis/100f);
    }
}
