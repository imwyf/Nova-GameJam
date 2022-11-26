using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 本脚本实现：
/// 1.对玩家的伤害
/// 2.玩家一碰就碎？（还是有血量？）
/// </summary>
public class Health : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        CheckDeath();
    }

    /// <summary>
    /// true = increase health
    /// </summary>
    /// <param name="isAdd"></param>
    public void ChangeHealth(bool isAdd)
    {
        if (isAdd) currentHealth++;
        else currentHealth--;
        // todo: 播放动画
    }

    private void CheckDeath()
    {
        if (currentHealth <= 0)
        {
            // todo: 播放动画，弹出再来一次菜单等
            Destroy(gameObject);
        }
    }
}
