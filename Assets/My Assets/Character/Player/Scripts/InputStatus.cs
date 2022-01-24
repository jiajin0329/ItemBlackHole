using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStatus : MonoBehaviour
{
    [Header("item_black_hole開關")]
    public bool item_black_hole = false;

    void Update()
    {
        if(item_black_hole)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                item_black_hole = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                item_black_hole = true; ;
            }
        }
    }
}
