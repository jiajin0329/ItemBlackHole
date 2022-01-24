using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_FPS_Update : MonoBehaviour
{
    [SerializeField]
    private Text ui_text;

    private float deltaTime;

    private float unscaledDeltaTime;

    private byte fps;

    private string fps_s;

    private void Update()
    {
        unscaledDeltaTime = Time.unscaledDeltaTime;

        deltaTime += (unscaledDeltaTime - deltaTime) * 0.1f;
        fps = (byte)(1f / deltaTime);
        fps_s = fps + " fps";
        
        ui_text.text = fps_s;
    }
}
