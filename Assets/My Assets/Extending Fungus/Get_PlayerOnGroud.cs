using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using MoreMountains.CorgiEngine;
[CommandInfo(
    "Player",
    "Get_PlayerOnGroud",
    "Get_PlayerOnGroud")]
public class Get_PlayerOnGroud : Command
{
    ///<summary>
    ///玩家名稱
    ///</summary>
    [Header("玩家名稱")]
    [SerializeField]
    private string pName;

    ///<summary>
    ///讀取玩家物件
    ///</summary>
    static private GameObject p_go;
    static private CorgiController cc;

    public override void OnEnter()
    {
        //如果還沒有使用或不相同尋找角色物件
        if(p_go == null)
        {
            p_go = GameObject.Find(pName);
            Debug.Log("找到 " + p_go.name);
            cc = p_go.GetComponent<CorgiController>();
        }

        GetComponent<Flowchart>().SetBooleanVariable("onGround", cc.State.IsGrounded);

        Continue();
    }
}
