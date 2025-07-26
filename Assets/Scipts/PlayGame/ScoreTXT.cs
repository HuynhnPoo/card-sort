using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTXT : TextBase
{
    private void Update()
    {
        text.SetText("coin: "+ GameManager.Instance.Score);
    }
}
