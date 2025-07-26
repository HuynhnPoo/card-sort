using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExitButton : ButtonBase
{
    public override void OnClick()
    {
        //ham tho�t chuong tr�nh
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity 
#endif
    }
}

