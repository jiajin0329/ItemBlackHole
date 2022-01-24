using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ThreadTest : MonoBehaviour
{
    #region 變數宣告 ===============================================================================================================

    /// <summary>
    /// 程式清單
    /// </summary>
    static private List<ThreadTest> scripts_list = new List<ThreadTest>();

    private ThreadTest tt;

    /// <summary>
    /// 程式更新率
    /// </summary>
    [Header("程式更新率")]
    [SerializeField]
    private float rate = 60f;

    static private Thread t;

    #endregion =============================================================================================================== 變數宣告

    #region 函式 ===============================================================================================================

    /// <summary>
    /// 初始化函式
    /// </summary>
    private void Init()
    {
        tt = GetComponent<ThreadTest>();
        scripts_list.Add(tt);
    }

    private void Start()
    {
        Init();

        if(t == null)
        {
            t = new Thread(_Main);
            t.Start();
        }
    }
    
    void _Main()
    {
        rate = 1f / rate;
        int wait = (int)(1000 * rate);
        ushort i;
        
        while(true)
        {
            for(i = 0; i < scripts_list.Count; i++)
            {
                //放重複執行的程式
            }
            Thread.Sleep(wait);
        }
    }

    private void Stop_Thread()
    {
        scripts_list.Remove(tt);

        if(scripts_list.Count < 1)
        {
            t.Abort();
            t = null;
            print("ThreadTest關閉");
        }
    }

    private void OnDisable()
    {
        Stop_Thread();
    }

    #endregion =============================================================================================================== 函式
}