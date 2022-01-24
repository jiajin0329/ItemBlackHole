using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Follw_WorldPos : MonoBehaviour
{
    /// <summary>
    /// 目標座標
    /// </summary>
    [Header("目標座標")]
    public Transform target;

    /// <summary>
    /// Canvas
    /// </summary>
    [Header("Canvas")]
    [SerializeField]
    private RectTransform canvas;

    private RectTransform rt;

    private void Follow_Worldpos()
    {
        rt.localPosition = Logic.WorldToUI(canvas, target.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(canvas == null)canvas = transform.parent.GetComponent<RectTransform>();

        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void Update()
    {
        Follow_Worldpos();
    }
}
