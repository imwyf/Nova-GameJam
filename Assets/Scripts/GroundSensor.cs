using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 本脚本实现player的地面检测，通过一个trigger实现碰撞，给isGround标记赋值
/// </summary>
public class GroundSensor : MonoBehaviour
{
    public bool isGround;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground")||other.CompareTag("Player"))
            isGround = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isGround = false;
    }
}
