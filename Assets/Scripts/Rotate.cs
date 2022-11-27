using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 本脚本实现：
/// 1.旋转物体，每秒旋转angle度
/// </summary>
public class Rotate : MonoBehaviour
{
    public float speed; // 旋转转速,单位度/秒
    Rigidbody2D rb2D;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb2D.angularVelocity = speed;
    }
}
