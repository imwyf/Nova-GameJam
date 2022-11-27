using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 本脚本实现：
/// 1.转换接触到的对象的磁性
/// </summary>
public class SwitchMagnet : MonoBehaviour
{
    public string magnetTag; // 转化成的磁性标签
    private void OnCollisionEnter2D(Collision2D other)
    {
        var other_MS = other.transform.Find("MagnetSensor"); // 拿到碰撞对象的磁力传感器
        var other_MG = other.transform.Find("MagnetGen"); // 拿到碰撞对象的磁场数据
        if (other_MS != null) other_MS.tag = magnetTag;
        if (other_MG != null) other_MG.tag = magnetTag;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var other_MS = other.transform.Find("MagnetSensor"); // 拿到碰撞对象的磁力传感器
        var other_MG = other.transform.Find("MagnetGen"); // 拿到碰撞对象的磁场数据
        if (other_MS != null) other_MS.tag = magnetTag;
        if (other_MG != null) other_MG.tag = magnetTag;
    }
}
