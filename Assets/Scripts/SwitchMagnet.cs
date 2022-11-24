using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 本脚本实现：
/// 1.转换接触到的对象的磁性,转换为自己（本脚本所挂载的对象）的tag
/// </summary>
public class SwitchMagnet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var other_MS_trans = other.transform.Find("MagnetSensor"); // 拿到碰撞对象的磁力传感器
        if (other_MS_trans != null) other_MS_trans.tag = this.tag;
    }
}
