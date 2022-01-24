using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo(
    "Say",
    "LookSpeaker",
    "LookSpeaker")]
public class LookSpeaker : Command
{
    ///<summary>
    ///說話人
    ///</summary>
    [Header("說話人")]
    [SerializeField]
    private Transform speaker;

    ///<summary>
    ///說話人Character
    ///</summary>
    private MoreMountains.CorgiEngine.Character speaker_ch;
    
    ///<summary>
    ///聆聽者Character
    ///</summary>
    [Header("聆聽者Character")]
    [SerializeField]
    private MoreMountains.CorgiEngine.Character[] listeners_ch;

    public override void OnEnter()
    {
        speaker_ch = speaker.GetComponent<MoreMountains.CorgiEngine.Character>();

        for(byte i = 0; i < listeners_ch.Length; i++)
        {
            bool speaker_on_right;

            if(speaker_ch != listeners_ch[i])
            {
                //機算說話人在聽眾的左右邊
                if(speaker.transform.position.x - listeners_ch[i].transform.position.x > 0)
                {
                    speaker_on_right = true;
                }
                else
                {
                    speaker_on_right = false;
                }

                //如果聽眾沒有面向說話人要轉向
                if(listeners_ch[i].CharacterModel.transform.localScale.x > 0)
                {
                    if(!speaker_on_right)
                    {
                        listeners_ch[i].Flip();
                    }
                }
                else
                {
                    if(speaker_on_right)
                    {
                        listeners_ch[i].Flip();
                    }
                }
            }
        }

        Continue();
    }
    public override string GetSummary()
    {
        if(speaker == null)
        {
            return "Error: speaker not set";
        }

        if(listeners_ch == null || listeners_ch.Length < 1)
        {
            return "Error: listeners_ch not set";
        }

        for(byte i = 0; i < listeners_ch.Length; i++)
        {
            if(listeners_ch[i] == null)
            {
                return "Error: No listeners_ch[" + i + "] selected";
            }
        }

        return speaker.name;
    }
}
