using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBase : MonoBehaviour,ILoadCopoment
{
    [SerializeField] protected TextMeshProUGUI text;
    public void LoadCopoment()
    {
        if (text == null) text = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
   protected virtual  void Start()
    {
        LoadCopoment();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
