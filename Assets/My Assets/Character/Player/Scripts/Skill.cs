using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

public class Skill : MonoBehaviour
{
    /// <summary>
    /// 玩家物件
    /// </summary>
    [Header("玩家物件")]
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// CharacterHandleSecondaryWeapon
    /// </summary>
    [Header("CharacterHandleSecondaryWeapon")]
    [SerializeField]
    private List<CharacterHandleSecondaryWeapon> chsw_list = new List<CharacterHandleSecondaryWeapon>();

    /// <summary>
    /// 自定義按鍵
    /// </summary>
    [Header("自定義按鍵")]
    [SerializeField]
    private KeyCode[] skill_key_codes;

    private void Start()
    {
        CharacterHandleSecondaryWeapon[] chsw = player.GetComponents<CharacterHandleSecondaryWeapon>();
        
        for(byte i = 0; i < chsw.Length; i++)
        {
            chsw_list.Add(chsw[i]);
        }
    }

    private void _Skill()
    {
        for(byte i = 0; i < skill_key_codes.Length; i++)
        {
            //判斷自定義鍵清單是否有按下
            if(Input.GetKeyDown(skill_key_codes[i]))
            {
                chsw_list[i].ShootStart();
                
                // print("skill");
            }
        }
    }
    
    private void FixedUpdate()
    {
        _Skill();
    }
}
