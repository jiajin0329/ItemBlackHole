using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Soul : MonoBehaviour
{
    #region 變數宣告 ===============================================================================================================
    /// <summary>
    /// 魂量
    /// </summary>
    [Header("魂量")]
    [Range(1, 255)]
    public byte soul = 1;

    /// <summary>
    /// Light2D_Controller
    /// </summary>
    [SerializeField]
    private Light2D_Controller l2dc;

    /// <summary>
    /// 最小大小
    /// </summary>
    [Header("最小大小")]
    [SerializeField]
    private float scale_min = 0.1f;

    /// <summary>
    /// 最大大小
    /// </summary>
    [Header("最大大小")]
    [SerializeField]
    private float scale_max = 0.3f;

    /// <summary>
    /// 特效
    /// </summary>
    [SerializeField]
    [Header("特效物件")]
    private GameObject effect;

    /// <summary>
    /// 特效光動畫控制器
    /// </summary>
    [SerializeField]
    [Header("特效光動畫控制器")]
    private Animator effect_light_ani;

    /// <summary>
    /// 粒子特效
    /// </summary>
    [SerializeField]
    [Header("粒子特效")]
    private ParticleSystem ps;

    /// <summary>
    /// 音效撥放器
    /// </summary>
    [Header("音效撥放器")]
    [SerializeField]
    private AudioSource sound_as;

    /// <summary>
    /// static音效撥放器
    /// </summary>
    static private AudioSource static_sound_as;

    /// <summary>
    /// 此遊戲物件
    /// </summary>
    private GameObject go;
    #endregion =============================================================================================================== 變數宣告

    #region 函式 ===============================================================================================================
    /// <summary>
    /// 初始化函式
    /// </summary>
    private void Initialize()
    {
        if(static_sound_as == null)
        {
            if (sound_as == null)
            {
                sound_as = GameObject.Find("SoundManager").transform.Find("Soul").GetComponent<AudioSource>();
            }

            static_sound_as = sound_as;
        }
    }

    /// <summary>
    /// 調整大小函式，回傳倍率
    /// </summary>
    private float Times()
    {
        float times = 1 + (scale_max/scale_min - 1) * (soul-1f) / (10f-1f);
        transform.localScale = Vector3.one * scale_min * times;
        return times;
    }

    /// <summary>
    /// 加血函式
    /// </summary>
    public void AddHP()
    {
        soul--;

        ps.Play();
        static_sound_as.Play();
        if(soul < 1)
        {
            effect.transform.SetParent(null);
            effect_light_ani.enabled = true;
            Destroy(effect, 3f);
            Destroy(gameObject);
        }
    }
    #endregion =============================================================================================================== 函式

    private void Start()
    {
        Initialize();
    }
}
