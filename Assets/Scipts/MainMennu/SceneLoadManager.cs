using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : ButtonBase
{
    [SerializeField] private TypeScene typeScene = TypeScene.MAINMENU;
    public enum TypeScene
    {
        MAINMENU,
        PLAYGAME
    }


    public override void OnClick()
    {
        ChangeScene(typeScene);
    }

    void ChangeScene(TypeScene typeScene)
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.IsPaused) { GameManager.Instance.IsPaused = false; }
        }
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(typeScene.ToString());
    }

}
