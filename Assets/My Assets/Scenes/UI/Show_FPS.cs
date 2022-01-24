using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Show_FPS : MonoBehaviour
{
    [SerializeField]
    private Text ui_text;

    //private float deltaTime;

    private float unscaledDeltaTime;

    private string fps_s;

    /// <summary>
    /// 程式更新率
    /// </summary>
    [Header("程式更新率")]
    [SerializeField]
    private float rate = 60f;

    private Thread t;

    private void _Show_FPS()
    {
        rate = 1f / rate;
        int wait = (int)(1000 * rate);
        byte fps;
        float deltaTime = 0f;
        
        while(true)
        {
            deltaTime += (unscaledDeltaTime - deltaTime) * 0.1f;
            fps = (byte)(1f / deltaTime);
            fps_s = fps + " fps";

            Thread.Sleep(wait);
        }
    }

    private void Start()
    {
        t = new Thread(_Show_FPS);
        t.Start();
    }

    private void Update()
    {
        unscaledDeltaTime = Time.unscaledDeltaTime;
        
        ui_text.text = fps_s;
    }

    private void OnDestroy()
    {
        t.Abort();
    }

    private void OnApplicationQuit()
    {
        t.Abort();
    }
}
