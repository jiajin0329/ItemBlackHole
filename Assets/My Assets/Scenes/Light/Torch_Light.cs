using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Threading;

public class Torch_Light : MonoBehaviour
{
    /// <summary>
    /// 火把光清單
    /// </summary>
    static private List<Torch_Light> scripts_list = new List<Torch_Light>();

    /// <summary>
    /// 起始倍率
    /// </summary>
    [Header("現在倍率")]
    [SerializeField]
    private float now_times;

    /// <summary>
    /// 光強度
    /// </summary>
    [Header("光強度")]
    [SerializeField]
    private float intensity = 0f;

    /// <summary>
    /// 外光圈
    /// </summary>
    [Header("外光圈")]
    [SerializeField]
    private float outer_radius = 0f;

    private Torch_Light tl;

    /// <summary>
    /// 起始倍率
    /// </summary>
    [Header("起始倍率")]
    [SerializeField]
    private float start_times = 0.7f;

    

    /// <summary>
    /// 級距
    /// </summary>
    [Header("級距")]
    [SerializeField]
    private float interval = 0.1f;

    /// <summary>
    /// 平滑時間
    /// </summary>
    [Header("平滑時間")]
    [SerializeField]
    private float smooth_time = 0.2f;

    /// <summary>
    /// 2D光
    /// </summary>
    [Header("2D光")]
    [SerializeField]
    private Light2D light_2d;

    /// <summary>
    /// 起始平滑倍率
    /// </summary>
    private float smooth_start_times = 0f;

    /// <summary>
    /// 目標倍率
    /// </summary>
    float target_times;

    /// <summary>
    /// 平滑百分比
    /// </summary>
    private float per;

    /// <summary>
    /// 火焰Particles
    /// </summary>
    [Header("火焰Particles")]
    [SerializeField]
    private ParticleSystem fire;

    /// <summary>
    /// 火花Particles
    /// </summary>
    [Header("火花Particles")]
    [SerializeField]
    private ParticleSystem spark;

    /// <summary>
    /// 粒子數量
    /// </summary>
    private int ps_count;

    /// <summary>
    /// 上次粒子數量
    /// </summary>
    private int last_ps_count;

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
    protected void Init()
    {
        intensity = light_2d.intensity;
        outer_radius = light_2d.pointLightOuterRadius;
    }

    private void Start()
    {
        Init();

        smooth_time = 1/smooth_time;

        spark.time = Random.Range(0f, 1.5f);

        tl = GetComponent<Torch_Light>();
        scripts_list.Add(tl);

        if(t == null)
        {
            t = new Thread(_Torch_Light);
            t.Start();
        }
    }
    
    private void _Torch_Light()
    {
        rate = 1f / rate;
        int wait = (int)(1000 * rate);
        ushort i;

        while(true)
        {
            for(i = 0; i < scripts_list.Count; i++)
            {
                if(scripts_list[i].ps_count != scripts_list[i].last_ps_count)
                {
                    scripts_list[i].target_times = scripts_list[i].start_times + scripts_list[i].interval * (scripts_list[i].ps_count-1);
                    scripts_list[i].smooth_start_times = scripts_list[i].now_times;
                    scripts_list[i].per = 0;
                }
                scripts_list[i].last_ps_count = scripts_list[i].ps_count;

                scripts_list[i].per += scripts_list[i].smooth_time * rate;

                if(scripts_list[i].per > 1)scripts_list[i].per = 1;

                scripts_list[i].now_times = Mathf.SmoothStep(scripts_list[i].smooth_start_times, scripts_list[i].target_times, scripts_list[i].per);

                //print("火把光運算");
            }

            Thread.Sleep(wait);
        }
    }

    /// <summary>
    /// 設定光源函式
    /// </summary>
    protected void Light_Set()
    {
        light_2d.intensity = intensity * now_times;
        light_2d.pointLightOuterRadius = outer_radius * now_times;
        //print("火把光源設定");
    }

    private void Update()
    {
        ps_count = fire.particleCount;
        Light_Set();
    }

    private void Stop_Thread()
    {
        scripts_list.Remove(tl);

        if(scripts_list.Count < 1)
        {
            t.Abort();
            t = null;
            print("Torch_Light關閉");
        }
    }

    private void OnDisable()
    {
        Stop_Thread();
    }
}
