using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

public class Logic_ItemPicker : MonoBehaviour
{
    /// <summary>
    /// 吸收中靈魂清單
    /// </summary>
    private List<Soul> soul = new List<Soul>();

    /// <summary>
    /// 計時器
    /// </summary>
    [SerializeField]
    [Header("計時器")]
    private float timer;

    /// <summary>
    /// 目標Layer
    /// </summary>
    [Header("目標Layer")]
    [SerializeField]
    private byte target_layer;

    /// <summary>
    /// 玩家血量
    /// </summary>
    [SerializeField]
    [Header("每秒吸魂量")]
    [Range(1, 255)]
    private byte add_soul = 3;

    /// <summary>
    /// 玩家血量
    /// </summary>
    [SerializeField]
    [Header("玩家血量")]
    private Health health;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        int co_layer = collision.gameObject.layer;

        if(co_layer == target_layer)
        {
            soul.Add(collision.GetComponent<Soul>());
            Debug.Log("撿到Soul");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int co_layer = collision.gameObject.layer;

        if (co_layer == target_layer)
            soul.Remove(collision.GetComponent<Soul>());
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(soul.Count > 0)
        {
            if (timer > 1f/add_soul)
            {
                soul[0].AddHP();
                timer = 0f;
            }
        }
    }
}
