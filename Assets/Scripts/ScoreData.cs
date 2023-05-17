using UnityEngine;
using UnityEngine.UI;

public class ScoreData : MonoBehaviour {
 
    public static ScoreData Instance;
 
    //要保存使用的数据;
    public int Score_red;
    public int Score_blue;
    public int Count_down;
 
    //初始化
    public void Awake()
    {
        if(Instance==null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance!=null)
        { 
            Destroy(gameObject);
        }
    }
}