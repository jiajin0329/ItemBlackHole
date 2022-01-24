using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.CorgiEngine;

public class HealthBar : MonoBehaviour
{
    ///<summary>
    ///柯基血量程式
    ///</summary>
    [Header("柯基血量程式")]
    [SerializeField]
    public Health health;

    ///<summary>
    ///控制UI清單
    ///</summary>
    [Header("HP的Slider")]
    [SerializeField]
    public Slider slider;

    public void Update()
    {
        slider.value = health.CurrentHealth;
    }
}
