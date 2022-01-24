using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Organ : MonoBehaviour
{
    /// <summary>
    /// 是否觸發
    /// </summary>
    [Header("是否觸發")]
    [SerializeField]
    private bool trigger;

    /// <summary>
    /// 開關
    /// </summary>
    [Header("開關")]
    [SerializeField]
    private bool _switch;

    /// <summary>
    /// 2D光
    /// </summary>
    [Header("2D光")]
    [SerializeField]
    private Light2D light_2d;
    private float start_intensity;

    /// <summary>
    /// 目標亮度
    /// </summary>
    [Header("目標亮度")]
    [SerializeField]
    private float target_intensity;


    /// <summary>
    /// 按鈕SpriteRenderer
    /// </summary>
    [Header("按鈕SpriteRenderer")]
    [SerializeField]
    private SpriteRenderer sr;

    /// <summary>
    /// 要控制的PlayableDirector
    /// </summary>
    [Header("要控制的PlayableDirector")]
    [SerializeField]
    private UnityEngine.Playables.PlayableDirector pd;

    private Coroutine c;

    private IEnumerator _Organ()
    {
        float per = 0f;
        float dif = target_intensity - start_intensity;

        while(true)
        {
            if(!_switch)
            {
                if(trigger)
                {
                //顯示按鍵
                    if(per < 1)
                    {
                        per += Time.deltaTime*3f;
                    }
                    else 
                    {
                        per = 1;
                    }
                }
                else
                {
                    if(per > 0)
                    {
                        per -= Time.deltaTime*3f;
                    }
                    else 
                    {
                        per = 0;
                    }
                }
            }
            else
            {
                per = 0;
            }
            

            light_2d.intensity = start_intensity + dif * per;
            sr.color = new Color(1,1,1,per);

            if(!(per > 0))
            {
                StopCoroutine(c);
                c = null;
                print("關閉_Organ");
            }

            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //如果物件layer是9(玩家)
        if(other.gameObject.layer == 9)
        {
            trigger = true;
            if(c == null)c = StartCoroutine(_Organ());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //如果物件layer是9(玩家)
        if(other.gameObject.layer == 9)
        {
            trigger = false;
        }
    }

    private void Update()
    {
        if(trigger)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                _switch = true;
                pd.Play();
            }
        }
    }
}
