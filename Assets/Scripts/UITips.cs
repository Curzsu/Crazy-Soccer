using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class UITips : MonoBehaviour
{
    public static Vector3 vec3, pos;
    void Start()
    {
        //刚开始控件为未激活状态
        gameObject.SetActive(false);
    }
    /// 按下鼠标将会触发事件
    public void PointerDown()
    {
        vec3 = Input.mousePosition;//获取当前鼠标的位置
        pos = transform.GetComponent<RectTransform>().position;//获取自己所在的位置
    }
    
    /// 鼠标拖拽时候会被触发的事件
    public void Drag()
    {
        Vector3 off = Input.mousePosition - vec3;
        //此处Input.mousePosition指鼠标拖拽结束的新位置
        //减去刚才在按下时的位置，刚好就是鼠标拖拽的偏移量
        vec3 = Input.mousePosition;//刷新下鼠标拖拽结束的新位置，用于下次拖拽的计算
        pos = pos + off;//原来image所在的位置自然是要被偏移
        transform.GetComponent<RectTransform>().position = pos;//直接将自己刷新到新坐标
    }
    
    /// 此函数接口将赋予给“弹出对话框”按钮的onClick事件
    public void onShow()
    {
        gameObject.SetActive(true);
    }
    
    /// 此函数接口将赋予给'OK'的onClick事件
    public void onOK()
    {
        gameObject.SetActive(false);
    }
}