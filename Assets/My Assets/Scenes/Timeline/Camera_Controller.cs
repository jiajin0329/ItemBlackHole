using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera_Controller : MonoBehaviour
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
    
    /// <summary>
    /// 要偵測的PlayableDirector
    /// </summary>
    [Header("要偵測的PlayableDirector")]
    [SerializeField]
    private UnityEngine.Playables.PlayableDirector pd;

    [SerializeField]
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    [SerializeField]
    private Transform tf;

    IEnumerator Set_Target(float time)
    {
        while(pd.time < time)
        {
            yield return new WaitForEndOfFrame();
        }
        cinemachineVirtualCamera.m_Follow = target[1];
    }

    IEnumerator Set_CamPOS()
    {
        Vector3 pos = tf.position;
        Vector2 Velocity = Vector2.zero;
        bool _switch = true;
        while(_switch)
        {
            yield return new WaitForEndOfFrame();
            
            if(Vector2.Distance(tf.position, target[0].position) > 0.03f && pd.time < 19.4167f)
            {
                pos.x = Mathf.SmoothDamp(tf.position.x, target[0].position.x, ref Velocity.x, smooth_time);
                pos.y = Mathf.SmoothDamp(tf.position.y, target[0].position.y, ref Velocity.y, smooth_time);

                tf.position = pos;

                print("smooth");
                
            }
            else if(pd.time < 19.4167f)
            {
                tf.position = target[0].position;
                _switch = false;
            }
        }
    }

    private void Start()
    {
        StartCoroutine(Set_CamPOS());
        StartCoroutine(Set_Target(19.4167f));
    }
}
