using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// 選單是否開啟
    /// </summary>
    private bool _switch = false;

    private Vector2 pos;

    [SerializeField]
    private RectTransform rt;

    private void _PauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!_switch)
            {
                Logic.timeScale = 0f;
                Time.timeScale = 0f;
                rt.localPosition = Vector2.zero;
                _switch = true;
            }
            else
            {
                CloseMenu();
                print("暫停選單");
            }
        }
        
    }

    /// <summary>
    /// 把暫停UI隱藏起來
    /// </summary>
    public void CloseMenu()
    {
        Logic.timeScale = 1f;
        Time.timeScale = 1f;
        rt.localPosition = pos;
        _switch = false;
    }

    private void Start()
    {
        pos = rt.localPosition;
    }

    private void Update()
    {
        _PauseMenu();
    }
}
