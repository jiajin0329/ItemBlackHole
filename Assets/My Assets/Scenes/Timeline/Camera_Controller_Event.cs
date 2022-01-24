using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera_Controller_Event : MonoBehaviour
{
    /// <summary>
    /// 演出座標
    /// </summary>
    [Header("抵達時間")]
    [SerializeField]
    private float smooth_time = 0.5f; 

    /// <summary>
    /// 座標
    /// </summary>
    [Header("設定目標")]
    [SerializeField]
    private Transform[] target = new Transform[1];

    [SerializeField]
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    [SerializeField]
    private Transform tf;
    
    private IEnumerator Set_Target_IE(int index)
    {
        cinemachineVirtualCamera.Follow = target[index];

        Vector3 pos = tf.position;
        Vector2 Velocity = Vector2.zero;
        bool _switch = true;
        while(_switch)
        {
            if(Vector2.Distance(tf.position, target[index].position) > 0.03f)
            {
                pos.x = Mathf.SmoothDamp(tf.position.x, target[index].position.x, ref Velocity.x, smooth_time);
                pos.y = Mathf.SmoothDamp(tf.position.y, target[index].position.y, ref Velocity.y, smooth_time);

                tf.position = pos;
            }
            else
            {
                tf.position = target[0].position;
                _switch = false;
            }

            print("smooth");
            yield return new WaitForEndOfFrame();
        }
    }
}
