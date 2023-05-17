using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool flag = false;
    public void PauseOrContinueGame()
    {
        if (!flag)
        {
            Time.timeScale = 0;
            flag = true;
        }
        else
        {
            Time.timeScale = 1;
            flag = false;
        }
    }
}
