using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject;
using BehaviorDesigner.Runtime.Tasks.Basic.UnityTime;
using DG.Tweening;
using FootBallAI;
using UnityEngine;
using UnityEngine.UI;
public class CountDown : MonoBehaviour
{
    public GameObject text;
    public Text over_text;
    public int TotalTime = 60;
    public int oldTime = 0;
    private static int flag = 0;

    void Start()
    {
        if(flag > 0) TotalTime = ScoreData.Instance.Count_down;
        flag += 1;
        StartCoroutine(Time());
    }

    IEnumerator Time()
    {
        while (TotalTime >= 0)
        {
            text.GetComponent<Text>().text = TotalTime.ToString();
            yield return new WaitForSeconds(1);
            TotalTime--;
            ScoreData.Instance.Count_down = TotalTime;
        }
    }

    void Update()
    {
        if(TotalTime < 10) text.GetComponent<Text>().color = Color.red;
        if (TotalTime < 1) //UnityEngine.Time.timeScale = 0;
        {
            over_text = GameObject.FindGameObjectWithTag("over").GetComponent<Text>();
            over_text.DOFade(2, 3);
            Ball ball = GameObject.FindObjectOfType<Ball>();
            Destroy(ball.GetComponent<Rigidbody>());
            transform.DOShakePosition(2, 3);
        }
    }
}