using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

public class Attack : MonoBehaviour
{
    /// <summary>
    /// 自定義方向攻機鍵
    /// </summary>
    [System.Serializable]
    private struct attack
    {
        /// <summary>
        /// 方向按鍵
        /// </summary>
        [Header("方向按鍵")]
        [SerializeField]
        private KeyCode direction_key;
        public KeyCode _direction_key {get { return direction_key; } }

        /// <summary>
        /// 武器index
        /// </summary>
        [Header("武器index")]
        [SerializeField]
        private byte weapon_index;
        public byte _weapon_index {get { return weapon_index; } }
    }

    /// <summary>
    /// 是否在地上
    /// </summary>
    [Header("是否在地上")]
    [SerializeField]
    private bool on_ground;

    /// <summary>
    /// CharacterHandleWeapon清單
    /// </summary>
    [Header("CharacterHandleWeapon清單")]
    [SerializeField]
    private List<CharacterHandleWeapon> chs_list;

    /// <summary>
    /// 攻擊按鍵
    /// </summary>
    [Header("攻擊按鍵")]
    [SerializeField]
    private KeyCode combat_key_codes;
    private bool combat_key_codes_bool;

    /// <summary>
    /// 地上各方向攻擊
    /// </summary>
    [Header("地上各方向攻擊")]
    [SerializeField]
    private attack[] ground_attack;
    private attack ground_normal_attack;

    /// <summary>
    /// 空中各方向攻擊
    /// </summary>
    [Header("空中各方向攻擊")]
    [SerializeField]
    private attack[] air_attack;
    private attack air_normal_attack;

    /// <summary>
    /// 玩家物件
    /// </summary>
    [Header("玩家物件")]
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// CorgiController
    /// </summary>
    private CorgiController cc;    

    // Start is called before the first frame update
    private void Start()
    {
        cc = player.GetComponent<CorgiController>();

        CharacterHandleWeapon[] chw = player.GetComponents<CharacterHandleWeapon>();
        
        for(byte i = 0; i < chw.Length; i++)
        {
            chs_list.Add(chw[i]);
        }

        for(byte i = 0; i < ground_attack.Length; i++)
        {
            if(ground_attack[i]._direction_key == KeyCode.None)
            {
                ground_normal_attack = ground_attack[i];
            }
        }

        for(byte i = 0; i < air_attack.Length; i++)
        {
            if(air_attack[i]._direction_key == KeyCode.None)
            {
                air_normal_attack = air_attack[i];
            }
        }
    }

    private void _Combat()
    {   
        combat_key_codes_bool = Input.GetKeyDown(combat_key_codes);        

        //讀取CorgiController.State.IsGrounded(是否在地上變數)
        on_ground = cc.State.IsGrounded;

        if(combat_key_codes_bool)
        {
            bool use_special_attack = false;

            if(on_ground)
            {
                for(byte i = 0; i < ground_attack.Length; i++)
                {
                    if(Input.GetKey(ground_attack[i]._direction_key))
                    {
                        chs_list[ground_attack[i]._weapon_index].ShootStart();
                        use_special_attack = true;
                        print(ground_attack[i]._direction_key.ToString() + " ground attack");
                        break;
                    }
                }

                if(!use_special_attack)
                {
                    chs_list[ground_normal_attack._weapon_index].ShootStart();
                    use_special_attack = false;
                    print(ground_normal_attack._direction_key.ToString() + " ground attack");
                }
            }
            else
            {
                for(byte i = 0; i < air_attack.Length; i++)
                {
                    if(Input.GetKey(air_attack[i]._direction_key))
                    {
                        chs_list[air_attack[i]._weapon_index].ShootStart();
                        use_special_attack = true;
                        print(air_attack[i]._direction_key.ToString() + " air attack");
                        break;
                    }
                }

                if(!use_special_attack)
                {
                    chs_list[air_normal_attack._weapon_index].ShootStart();
                    use_special_attack = false;
                    print(air_normal_attack._direction_key.ToString() + " air attack");
                }
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _Combat();
    }
}