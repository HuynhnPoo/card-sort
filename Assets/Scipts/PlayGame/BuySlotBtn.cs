using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySlotBtn : ButtonBase
{
    [SerializeField] private InfoSlotSO infoSlotSO;

    int price;
    bool isBought;
    private void OnEnable()
    {
        price=infoSlotSO.price;
        isBought=infoSlotSO.isBought;
    }
    public override void OnClick()
    {
       this.BuyingSlot();
    }

    void BuyingSlot()
    {
        if (GameManager.Instance.Score > price)
        { 
            GameManager.Instance.Score -= price;
            Destroy(this.gameObject);
        }
        
        
    }
}
