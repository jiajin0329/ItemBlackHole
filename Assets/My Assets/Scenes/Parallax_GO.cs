using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Parallax_GO : MonoBehaviour
{
    /// <summary>
    /// 程式清單
    /// </summary>
    static private List<Parallax_GO> scripts_list = new List<Parallax_GO>();

    private Parallax_GO pg;

    /// <summary>
    /// y速度
    /// </summary>
    [Header("y速度")]
    [SerializeField]
    private float y_speed;

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
    private Vector3 start_pos;

    /// <summary>
    /// 目標
    /// </summary>
    [Header("目標")]
    [SerializeField]
    private Transform target;

    /// <summary>
    /// 目標開始高度
    /// </summary>
    [Header("目標開始高度")]
    [SerializeField]
    private float target_start_pos_y;

    /// <summary>
    /// 目標座標
    /// </summary>
    private Vector2 target_pos;

    ///視差座標
    private Vector2 parallax_pos;

    /// <summary>
    /// 結算座標
    /// </summary>
    private Vector3 sum_pos;

    /// <summary>
    /// 程式更新率
    /// </summary>
    [Header("程式更新率")]
    [SerializeField]
    private float rate = 60f;

    static private Thread t;

    /// <summary>
    /// 初始化函式
    /// </summary>
    private void Init()
    {
        pg = GetComponent<Parallax_GO>();
        scripts_list.Add(pg);

        tm = transform;
        start_pos = tm.position;

        target_pos = target.position;
    }

    void Start()
    {
        Init();

        if(t == null)
        {
            t = new Thread(_Parallax_GO);
            t.Start();
        }
    }

    private void _Parallax_GO()
    {
        rate = 1f / rate;
        int wait = (int)(1000 * rate);
        ushort i;

        while(true)
        {
            for(i = 0; i < scripts_list.Count; i++)
            {
                scripts_list[i].parallax_pos.x = scripts_list[i].target_pos.x - scripts_list[i].start_pos.x;
                scripts_list[i].parallax_pos.y = scripts_list[i].target_pos.y - scripts_list[i].target_start_pos_y;

                scripts_list[i].sum_pos = scripts_list[i].start_pos +
                new Vector3(scripts_list[i].parallax_pos.x, scripts_list[i].parallax_pos.y * scripts_list[i].y_speed, 0) * scripts_list[i].dis*0.01f;
            }

            Thread.Sleep(wait);
        }
    }

    void Update()
    {
        target_pos = target.position;

        tm.position = sum_pos;
    }

    private void Stop_Thread()
    {
        scripts_list.Remove(pg);

        if(scripts_list.Count < 1)
        {
            t.Abort();
            t = null;
            print("Parallax_GO關閉");
        }
    }

    private void OnDisable()
    {
        Stop_Thread();
    }
}
