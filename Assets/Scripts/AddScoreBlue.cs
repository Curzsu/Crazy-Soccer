using System;
using System.Collections;
using System.Collections.Generic;
using FootBallAI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddScoreBlue : MonoBehaviour {
    public static Text blue_txt;				//定义静态变量名以用于其他脚本内的引用
    public static float x = 0;
    public delegate void PlayerScore(int temp);//定义委托
    private int oldData = 0;
    public event PlayerScore GetScore;//定义得分事件，用于发出得分的消息
    public static AddScoreBlue instance = null;              //为这个类创建实例
    void Start () 
    {
        blue_txt = GameObject.FindWithTag("blue").GetComponent<Text> ();
        oldData = ScoreData.Instance.Score_blue;
        Debug.Log("blue " + oldData);
    }

    public void Update()
    {
        blue_txt.text = oldData.ToString();
    }
    
    public void OnTriggerEnter(Collider other)//设置触发器碰撞事件，一旦Player穿过了ScoreObj,就发送得分事件
    {
        if (other.gameObject.name.Equals("Ball"))//检查Player碰撞的物体是不是ScoreObj
        {
            if (GetScore != null)//检查事件是否为空，即有没有接收器订阅它
            {
                Debug.Log("blue666");
                GetScore(1);//发送得分事件消息，为接收器提供参数1，实现+1分的效果
            }
        }
    }
}