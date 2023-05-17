using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.LoadScene(1);
        ScoreData.Instance.Score_red = 0;
        ScoreData.Instance.Score_blue = 0;
        ScoreData.Instance.Count_down = 60;
        
    }
}
