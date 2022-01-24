using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo(
    "SayDialgo",
    "SetSayDialgo_Follow",
    "SetSayDialgo_Follow")]
public class SetSayDialgo_Follow : Command
{
    ///<summary>
    ///對話框物件
    ///</summary>
    [Header("對話框物件")]
    [SerializeField]
    private UI_Follw_WorldPos ufw;

    ///<summary>
    ///UI追蹤座標
    ///</summary>
    [Header("UI追蹤座標")]
    [SerializeField]
    private Transform follow;

    public override void OnEnter()
    {
        ufw.target = follow;

        Continue();
    }
    public override string GetSummary()
    {
        if (follow != null && ufw != null)
        {
            return follow.name;
        }

        return "Error: No selected";
    }
}
