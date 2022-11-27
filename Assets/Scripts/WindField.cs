using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 本脚本实现：
/// 1.风场的管理
/// </summary>
public class WindField : MonoBehaviour
{
    public string toward; // 风向
    public float force; // 力度
    private void OnTriggerStay2D(Collider2D other)
    {
        var other_rb2D = other.GetComponent<Rigidbody2D>();
        if (other_rb2D == null) return;
        switch (toward)
        {
            case "up": other_rb2D.AddForce(Vector2.up * force); break;
            case "down": other_rb2D.AddForce(Vector2.down * force); break;
            case "left": other_rb2D.AddForce(Vector2.left * force); break;
            case "right": other_rb2D.AddForce(Vector2.right * force); break;
            default: break;
        }
    }
}
