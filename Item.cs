using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    /// <summary>
    /// 重量
    /// </summary>
    [Header("重量")]
    [Range(1, 10)]
    public byte weight = 1;

    [Header("座標")]
    public Vector2 pos;

    [Header("移動座標")]
    public Vector2 move_pos;

    static private ItemBlackHole item_black_hole;

    private Transform tf;

    private void Start()
    {
        tf = transform;

        pos = transform.position;

        if(item_black_hole == null)GameObject.Find("ItemBlackHole").GetComponent<ItemBlackHole>();
    }

    private void Update()
    {
        tf.position = pos;
        pos = tf.position;
    }
}
