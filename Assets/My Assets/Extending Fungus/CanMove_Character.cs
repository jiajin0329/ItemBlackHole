using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using MoreMountains.CorgiEngine;
[CommandInfo(
    "Pause",
    "CanMove_Character",
    "CanMove_Character")]
public class CanMove_Character : Command
{
    ///<summary>
    ///設定時間速度
    ///</summary>
    [Header("是否可以移動")]
    [SerializeField]
    private bool play;

    ///<summary>
    ///欲控制角色名稱
    ///</summary>
    [Header("欲控制角色名稱")]
    [SerializeField]
    private Transform character;

    ///<summary>
    ///控制中角色物件
    ///</summary>
    static private GameObject ch_go;
    static private MoreMountains.CorgiEngine.Character c;
    static private CharacterHorizontalMovement chm;
    static private CharacterRun cr;

    public override void OnEnter()
    {
        //如果還沒有使用或不相同尋找角色物件
        if(ch_go == null || ch_go.name != character.name)
        {
            ch_go = GameObject.Find(character.name);
            Debug.Log("找到 " + ch_go.name);
            c = ch_go.GetComponent<MoreMountains.CorgiEngine.Character>();
        }

        if(!play)
        {
            c.Freeze();
            c.CharacterAnimator.SetBool("Idle", true);
        }
        else
        {
            c.UnFreeze();
            c.CharacterAnimator.SetBool("Idle", false);
        }

        c.enabled = play;

        Continue();
    }

    public override string GetSummary()
    {
        if(character != null)
        {
            return character.name + " " + play;
        }
        
        return "Error: No characterName " + play;
    }
}
