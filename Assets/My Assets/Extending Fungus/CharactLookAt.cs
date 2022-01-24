using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo(
    "CorgiEngine",
    "CharactLookAt",
    "CharactLookAt")]
public class CharactLookAt : Command
{
    ///<summary>
    ///CorgiEngine.Character
    ///</summary>
    [Header("CorgiEngine.Character")]
    [SerializeField]
    private MoreMountains.CorgiEngine.Character[] ch;

    private enum dir_enum{right, left}

    ///<summary>
    ///說話人
    ///</summary>
    [Header("方向")]
    [SerializeField]
    private dir_enum[] dir;

    public override void OnEnter()
    {
        for(byte i = 0; i < ch.Length; i++)
        {
            if(dir[i] == dir_enum.left)
            {
                if(ch[i].CharacterModel.transform.localScale.x < 0)
                {
                    ch[i].Flip();
                }
            }
            else
            {
                if(ch[i].CharacterModel.transform.localScale.x > 0)
                {
                    ch[i].Flip();
                }
            }
        }
        Continue();
    }
    public override string GetSummary()
    {
        if(ch == null || ch.Length < 1) return　"Error: ch no set";
        if(dir == null|| dir.Length < 1) return　"Error: dir no set";
        
        if(ch.Length != dir.Length)
        {
            return　"Error: ch.Length != dir.Length";
        }

        for(byte i = 0; i < ch.Length; i++)
        {
            if(ch[i] == null) return　"Error: ch[" + i + "] no set";
        }

        string _print;

        for(byte i = 0; i < ch.Length; i++)
        {
            _print = ch[i].name + " " + dir[i].ToString() + "  "; 
        }

        return　null;
    }
}
