using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : ButtonBase
{
   [SerializeField] private GameObject pauseGame;
    public override void OnClick()
    {
        ChangePause();
    }

    void ChangePause()
    {
        if (!GameManager.Instance.IsPaused)
        {
            GameManager.Instance.PauseGame(pauseGame);
        }
        else
        {
            GameManager.Instance.ResumseGame(pauseGame);
        }
    }
}
