using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ItemBlackHole : MonoBehaviour
{
    #region 變數宣告 ===============================================================================================================

    /// <summary>
    /// 物品清單
    /// </summary>
    [Header("物品清單")]
    [SerializeField]
    private List<Item> item_list = new List<Item>();

    /// <summary>
    /// 物品Layer
    /// </summary>
    [Header("物品Layer")]
    [SerializeField]
    private int item_layer;

    /// <summary>
    /// 吸收半徑
    /// </summary>
    [Header("吸收半徑")]
    [SerializeField]
    private float radius;

    /// <summary>
    /// 輸入狀態
    /// </summary>
    [Header("輸入狀態")]
    [SerializeField]
    private InputStatus input_status;

    /// <summary>
    /// 吸力參數
    /// </summary>
    [Header("吸力參數")]
    [SerializeField]
    private byte pow = 12;

    /// <summary>
    /// 阻力參數
    /// </summary>
    [Header("阻力")]
    [SerializeField]
    private byte drag = 10;

    private Transform tf;

    private Vector2 pos;

    /// <summary>
    /// 程式更新率
    /// </summary>
    [Header("程式更新率")]
    [SerializeField]
    private float rate = 60f;

    private Thread t;

    #endregion =============================================================================================================== 變數宣告

    #region 函式 ===============================================================================================================

    private void Start()
    {
        Init();

        t = new Thread(ItemBlackHole2D);
        t.Start();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void Init()
    {
        tf = transform;

        if(input_status == null)input_status = GameObject.Find("InputStatus").GetComponent<InputStatus>();

        if (!(radius > 0))
        {
            //計算吸收半徑
            radius = tf.localScale.x * tf.GetComponent<CircleCollider2D>().radius;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == item_layer)
        {
            item_list.Add(collision.GetComponent<Item>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == item_layer)
        {
            item_list.Remove(collision.GetComponent<Item>());
        }
    }

    private void Update()
    {
        pos = tf.position;
    }

    /// <summary>
    /// 吸收主函式
    /// </summary>
    private void ItemBlackHole2D()
    {
        rate = 1f / rate;
        int wait = (int)(1000 * rate);
        float dis;
        //引力角度
        float g_angle;

        float move_speed;

        float sum_speed;

        ushort i;

        while(true)
        {
            for(i = 0; i < item_list.Count; i++)
            {
                if(input_status.item_black_hole)
                {
                    dis = Vector2.Distance(pos, item_list[i].pos);

                    if (dis < radius)
                    {
                        //計算受引力程度
                        float per = (radius - dis) / radius;
                        if(per > 1f)per = 1f;

                        //計算引力方向
                        g_angle = Mathf.Atan2(pos.x - item_list[i].pos.x, pos.y - item_list[i].pos.y) / (Mathf.PI / 180);

                        //加速
                        item_list[i].move_pos += drag * (1+(pow-drag)*0.5f*per) * rate * Logic.timeScale * new Vector2(Mathf.Sin(g_angle * Mathf.Deg2Rad), Mathf.Cos(g_angle * Mathf.Deg2Rad));
                        //print("吸力計算");
                    }
                }
                /*else
                {
                    print("吸收物品關閉");
                }*/ 

                if (item_list[i].move_pos != Vector2.zero)
                {
                    //阻力程式
                    //計算斜邊長度，等等要做等比縮放
                    move_speed = Vector2.Distance(item_list[i].move_pos, Vector2.zero);

                    //等比縮放
                    sum_speed = move_speed - (drag * rate * Logic.timeScale);
                    //print(sum);
                    item_list[i].move_pos *= sum_speed > 0 ? sum_speed / move_speed : 0;

                    item_list[i].pos += (item_list[i].move_pos * ((10-item_list[i].weight)/9f) * rate * Logic.timeScale);
                }
            }

            Thread.Sleep(wait);
        }        
    }

    private void Stop_Thread()
    {
        t.Abort();
        print("ItemBlackHole_Thread關閉");
    }

    private void OnDisable()
    {
        Stop_Thread();
    }

    #endregion =============================================================================================================== 函式
}
