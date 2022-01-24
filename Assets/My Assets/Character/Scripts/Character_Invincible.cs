using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

public class Character_Invincible : MonoBehaviour
{
    /// <summary>
    /// 開關
    /// </summary>
    [Header("開關")]
    [SerializeField]
    private bool _switch;

    /// <summary>
    /// 角色血量
    /// </summary>
    [Header("角色血量")]
    [SerializeField]
    private Health health;

    public IEnumerator _Character_Invincible(float invincible_time)
    {
        if(!_switch)
        {
            _switch = true;

            health.DamageDisabled();

            yield return new WaitForSeconds(invincible_time);

            health.DamageEnabled();

            _switch = false;
        }
        
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(_Character_Invincible(1f));
        }
    }
}
