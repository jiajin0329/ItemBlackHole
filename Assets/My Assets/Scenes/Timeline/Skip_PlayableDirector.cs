using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip_PlayableDirector : MonoBehaviour
{
    /// <summary>
    /// 要控制的PlayableDirector
    /// </summary>
    [Header("要控制的PlayableDirector")]
    [SerializeField]
    private UnityEngine.Playables.PlayableDirector pd;

    /// <summary>
    /// 跳到哪一秒
    /// </summary>
    [Header("跳到哪一秒")]
    [SerializeField]
    private float skip_time;

    /// <summary>
    /// 演出座標
    /// </summary>
    [Header("GameObject")]
    [SerializeField]
    private GameObject go;

    IEnumerator hide_skip(float time)
    {
        while(pd.time < time)
        {
            yield return new WaitForEndOfFrame();
        }
        go.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(hide_skip(skip_time));
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            pd.time = skip_time;
            go.SetActive(false);
        }
    }
}
