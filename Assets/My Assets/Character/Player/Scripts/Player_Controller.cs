using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player_Controller : MonoBehaviour
{
    /// <summary>
    /// 正在操作角色X
    /// </summary>
    [Header("正在操作角色X")]
    [SerializeField]

    private byte index;

    private byte last_index;

    private bool input = false;

    /// <summary>
    /// 攝影機程式
    /// </summary>
    [Header("攝影機程式")]
    [SerializeField]
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    /// <summary>
    /// 移動程式陣列
    /// </summary>
    [Header("移動程式陣列")]
    [SerializeField]
    private MoreMountains.CorgiEngine.Character[] characters_c = new MoreMountains.CorgiEngine.Character[4];

    /// <summary>
    /// 座標陣列
    /// </summary>
    [Header("座標陣列")]
    [SerializeField]
    private Transform[] characters_tm = new Transform[4];

    /// <summary>
    /// Amimator陣列
    /// </summary>
    [Header("Amimator陣列")]
    [SerializeField]
    private Animator[] characters_am = new Animator[4];

    private void My_Input()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            index = 1;
            input = true;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 2;
            input = true;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            index = 3;
            input = true;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            index = 4;
            input = true;
        }
    }

    private void _Switch_Character()
    {   
        My_Input();

        if(input)
        {
            characters_c[last_index-1].Freeze();
            characters_tm[last_index-1].gameObject.SetActive(false);
            characters_tm[index-1].localPosition = characters_tm[last_index-1].localPosition;
            //characters_tm[index-1].localScale = characters_tm[last_index-1].localScale;
            characters_tm[index-1].gameObject.SetActive(true);
            characters_c[index-1].UnFreeze();

            //設定攝影機目標
            cinemachineVirtualCamera.m_Follow = characters_tm[index-1];

            last_index = index;

            

            input = false;
        }
    }

    private void Start()
    {
        index = 1;
        last_index = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _Switch_Character();
    }
}
