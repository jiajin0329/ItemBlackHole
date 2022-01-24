using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo(
    "Sayialgo",
    "SetSayDialgo_GO",
    "SetSayDialgo_GO")]
public class SetSayDialgo_GO : Command
{
    ///<summary>
    ///搜尋父物件名稱
    ///</summary>
    [Header("搜尋父物件")]
    [SerializeField]
    private Transform parentGO;

    ///<summary>
    ///使用過的對話框清單
    ///</summary>
    static private List<SayDialog> sayDialog = new List<SayDialog>();

    ///<summary>
    ///使用中對話框索引值
    ///</summary>
    static private byte sayDialogIndex;

    public override void OnEnter()
    {
        if(sayDialog.Count > 0)
        {
            if(sayDialog[sayDialogIndex].transform.parent.name == parentGO.name)
            {
                Debug.Log("相同 " + sayDialog[0].name);
            }
            else
            {
                for(int i = 0; i < sayDialog.Count; i++)
                {
                    if(sayDialog[sayDialogIndex].transform.parent.name == parentGO.name)
                    {
                        sayDialogIndex = (byte)(i);
                        Debug.Log("找到 " + sayDialog[sayDialogIndex].name);
                        break;
                    }
                }
                AddSayDialogList();
            }
        }
        else
        {
            Debug.Log("沒找到");
            AddSayDialogList();
        }

        SayDialog.ActiveSayDialog = sayDialog[sayDialogIndex];

        Continue();
    }

    private void AddSayDialogList()
    {
        sayDialog.Add(GameObject.Find(parentGO.name).transform.Find("SayDialog").GetComponent<SayDialog>());
        sayDialogIndex = 0;

        Debug.Log("新增 " + sayDialog[sayDialogIndex].name);
    }

    public override string GetSummary()
    {
        if (parentGO != null)
        {
            return parentGO.name;
        }

        return "Error: No say parentGOName selected";
    }
}
