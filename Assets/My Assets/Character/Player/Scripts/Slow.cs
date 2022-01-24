using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    /// <summary>
    /// 慢動作
    /// </summary>
    [Header("慢動作")]
    [SerializeField]
    private bool slow;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            if(!slow)
            {
                Logic.timeScale = 0.1f;
                slow = true;
            }
            else
            {
                Logic.timeScale = 1f;
                slow = false;
            }
        }
    }
}
