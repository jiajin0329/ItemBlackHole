using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    /// <summary>
    /// 動畫
    /// </summary>
    [Header("動畫")]
    [SerializeField]
    private Animator am;

    /// <summary>
    /// 音效
    /// </summary>
    [Header("音效")]
    [SerializeField]
    private AudioClip ac;

    /// <summary>
    /// 音效撥放器
    /// </summary>
    [Header("音效撥放器")]
    [SerializeField]
    private AudioSource audio_Source;
    
    /// <summary>
    /// 復活Timeline
    /// </summary>
    [Header("復活Timeline")]
    [SerializeField]
    private UnityEngine.Playables.PlayableDirector relife;

    /// <summary>
    /// 復活Timeline
    /// </summary>
    [Header("主選單Timeline")]
    [SerializeField]
    private UnityEngine.Playables.PlayableDirector main_menu_cam;

    [SerializeField]
    private GameObject go;
    public void Start_Game()
    {
        am.enabled = true;
        audio_Source.clip = ac;
        audio_Source.Play();
    }

    private void Relife_Timeline()
    {
        relife.Play();
        main_menu_cam.Stop();
        go.SetActive(false);
    }
}
