using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 本脚本实现：
/// 1.脚踏式按钮的一个触发效果
/// 2.触发后可以调整切换磁性的装置（SwitchMagnet）
/// </summary>
public class ChangeSwitchMagnet : MonoBehaviour
{
    public GameObject switchMagnet; // 本物体绑定的SwitchMagnet
    SwitchMagnet SM;
    string[] statusPool = new string[4] { "N", "S", "Fe", "Non" }; // 状态池
    int i; // index of the status pool
    bool changePermitted = true; // 确认是否允许改变
    private void Awake()
    {
        SM = switchMagnet.GetComponent<SwitchMagnet>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!changePermitted) return;
        if (!other.CompareTag("Player") && !other.CompareTag("Interactive")) return; // 只有可互动的物体才能触发
        SM.magnetTag = statusPool[i++];
        if (i % 4 == 0) i = 0;
        changePermitted = false;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        changePermitted = true;
    }
}
