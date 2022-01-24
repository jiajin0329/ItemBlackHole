using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Light2D_Controller : MonoBehaviour
{
    #region 變數宣告 ===============================================================================================================
    /// <summary>
    /// 內光圈
    /// </summary>
    [Header("內光圈")]
    [SerializeField]
    private float inner_radius = 0f;

    /// <summary>
    /// 外光圈
    /// </summary>
    [Header("外光圈")]
    [SerializeField]
    private float outer_radius = 0f;

    /// <summary>
    /// 倍率
    /// </summary>
    [Header("倍率")]
    [SerializeField]
    public float inner_times = 1f;

    /// <summary>
    /// 倍率
    /// </summary>
    [Header("倍率")]
    [SerializeField]
    public float outer_times = 1f;

    /// <summary>
    /// 2D光
    /// </summary>
    [Header("2D光")]
    [SerializeField]
    private Light2D light_2d;
    #endregion =============================================================================================================== 變數宣告

    #region 函式 ===============================================================================================================
    /// <summary>
    /// 初始化函式
    /// </summary>
    protected void Init()
    {
        inner_radius = light_2d.pointLightInnerRadius;
        outer_radius = light_2d.pointLightOuterRadius;
    }

    /// <summary>
    /// 設定光源函式
    /// </summary>
    protected void Light_Set()
    {
        light_2d.pointLightInnerRadius = inner_radius * inner_times;
        light_2d.pointLightOuterRadius = outer_radius * outer_times;
        //print("火把光源設定");
    }
    #endregion =============================================================================================================== 函式
}
