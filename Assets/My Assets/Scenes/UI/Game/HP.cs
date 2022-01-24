using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.CorgiEngine;

public class HP : MonoBehaviour
{
    ///<summary>
    ///柯基血量程式
    ///</summary>
    [Header("柯基血量程式")]
    [SerializeField]
    private Health health;

    ///<summary>
    ///控制UI清單
    ///</summary>
    [Header("HP圖片")]
    [SerializeField]
    private Sprite[] hpSprite = new Sprite[1];
    
    ///<summary>
    ///控制Image清單
    ///</summary>
    [Header("控制Image清單")]
    [SerializeField]
    private Image[] hpImage = new Image[1];
    private int  hpimage_length;



    private void Start()
    {
        hpimage_length = hpImage.Length;
    }

    private void Update()
    {
        SetHpImage();
    }

    private void SetHpImage()
    {
        //血量點數：用來計算分配給每個UI的血量
        int hp_count = health.CurrentHealth;
        

        for(byte i = 0; i < hpImage.Length; i++)
        {
            if(hp_count > -1)
            {
                if(hp_count < hpImage.Length)
                {
                    hpImage[i].sprite = hpSprite[hp_count];
                }
                else
                {
                    hpImage[i].sprite = hpSprite[hpSprite.Length-1];
                }
            }

            //每發放完一輪-3
            hp_count -= hpimage_length;
        }
    }
}
