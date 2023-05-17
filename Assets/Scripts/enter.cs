using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class enter : MonoBehaviour
{
    public void Load()
    {
        SceneManager.LoadScene("Strategy/Team/MainScene"); //切换场景后销毁前场景
    }
}