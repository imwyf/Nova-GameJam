using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 本脚本实现：
/// 1.改变玩家血量
/// </summary>
public class ChangeHealth : MonoBehaviour
{
    public bool isDamage; // 是否造成伤害
    // todo: 无敌时间？
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<Health>().ChangeHealth(isDamage);
    }
}
