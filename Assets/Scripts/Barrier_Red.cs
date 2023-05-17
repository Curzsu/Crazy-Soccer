using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject;
using DG.Tweening;
using FootBallAI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;//引入unity的UI编辑库

public class Barrier_Red : MonoBehaviour
{
    public AddScoreRed player;//定义PlayerControl类
    public int score;//定义积分变量
    public Text ScoreUI;//定义要修改的Text
    private bool flag = false;
    public static bool red_win = false;

    void Start()
    {
        player.GetScore += Player_GetScore;//调用PlayerControl类，订阅Player的得分事件，start函数已经作为了我们的消息接收器
    }

    private void Update()
    {
        if (flag)
        {
            StartCoroutine(Thread1());
            flag = false;
        }
    }

    private void Player_GetScore(int score)//定义消息处理器来处理消息，给属性赋值，改变积分值
    {
        Score += score;
    }
    IEnumerator Thread1()
    {
        Debug.Log("3");
        yield return new WaitForSeconds(6.0f);
        SceneManager.LoadScene(1); //回到中场发球
        Debug.Log("2");
    }

    private int Score//定义积分属性，使用属性来进行控制，使每次积分被改变时就调用一次文本显示的修改
    {
        get
        {
            return score;
        }
        set
        {
            Debug.Log("1");
            score = value;
            ScoreUI.text = score.ToString();//让UI显示的分数等于score的值，这里有String类型的转换
            ScoreData.Instance.Score_red += score;
            showWin();
            flag = true;
        }
    }

    private void showWin()
    {
        Text text = GameObject.FindWithTag("red_winner").GetComponent<Text>();
        text.DOText("The red team scores!!!", 2); //2秒时间将这段文字逐字显示
        text.DOColor(Color.red, 4); //颜色逐渐变红
    }
}