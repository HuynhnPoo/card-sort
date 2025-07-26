using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour, ILoadCopoment
{
    protected Button button;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        LoadCopoment();
        AddClickEvent();

    }
    public void LoadCopoment()
    {
        if (button == null) button = GetComponent<Button>();
    }


    public virtual void AddClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }

    public abstract void OnClick();
}
