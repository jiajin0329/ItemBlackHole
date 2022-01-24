using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    /// <summary>
    /// 開關
    /// </summary>
    [SerializeField]
    [Header("開關")]
    private bool _switch = true;

    /// <summary>
    /// 生成物件
    /// </summary>
    [SerializeField]
    [Header("生成物件")]
    private GameObject item;

    private float timer;

    private void FixedUpdate()
    {
        if(_switch)
        {
            timer += Time.fixedDeltaTime;
            if (timer >= 0.5f)
            {
                GameObject go = Instantiate(item, transform.position, transform.rotation);
                
                timer = 0f;
            }
        }
    }
}
