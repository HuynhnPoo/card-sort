using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealButton : ButtonBase
{
    [SerializeField] private SlotsManager[] slot;

    public override void OnClick()
    {
        foreach (var slot in slot)
        {
           //if( slot.CheckIsEmpty())
                slot.Spawning();
            
        }
    }

   
}
