using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="SlotData")]
public class InfoSlotSO : ScriptableObject 
{
    public int price;
    public bool isBought=false;
}
