using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 本脚本实现：
/// 1.改变玩家血量
/// </summary>
public class ChangeHealth : MonoBehaviour
{
    public bool isAdd; // 是否加血
    // todo: 无敌时间？
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<Health>().ChangeHealth(isAdd);
    }
}
