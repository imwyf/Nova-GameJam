using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 本脚本实现：
/// 1.控制不带磁性的弹簧，模拟现实弹簧
/// 2.该脚本应该挂在sensor
/// </summary>
public class SpringSensor : MonoBehaviour
{
    //弹簧被压缩的程度越大，弹性越大
    Vector2 sPos; // 初始位置
    Vector2 cPos; // 现在的位置
    public float elasticValue = 3f; //弹性系数
    bool isPress; // 是否被压缩
    Rigidbody2D other_rb2D; // 弹簧上的物体的rb
    GameObject springScale; // 用来调整scale的物体
    private float exitTime = 1;
    private float exitTimer;

    private void Start()
    {
        sPos = transform.position; // 先获取初始状态下的弹簧中心位置
        springScale = transform.parent.gameObject;
        isPress = false;
        exitTimer = exitTime;
    }
    private void Update()
    {
        // 更新现在的位置
        cPos = transform.position;
        if (exitTimer < exitTime) exitTimer -= Time.deltaTime;
        if (exitTimer < 0) isPress = false;
        else isPress = true; 
        Debug.Log(isPress);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // 只能被玩家和可互动物体触发
        if (!other.transform.CompareTag("Player") && !other.transform.CompareTag("Interactive")) return;
        other_rb2D = other.gameObject.GetComponent<Rigidbody2D>();
        exitTimer = exitTime;
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (!other.transform.CompareTag("Player") && !other.transform.CompareTag("Interactive")) return;
        isPress = true;
        exitTimer = exitTime;
        float offset;
        Vector2 f = elasticValue * (cPos - sPos); // 弹簧的反弹力
        other_rb2D.AddForce(f);
        // 调整物体scale
        // if (other_rb2D.velocity.magnitude < 0.01f) offset = 0; // 当物体不动时，弹簧不形变
        offset = -0.1f;
        springScale.transform.localScale = new Vector3(springScale.transform.localScale.x, springScale.transform.localScale.y + offset, springScale.transform.localScale.z);

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        exitTimer = exitTime - 0.1f;
        Debug.Log(isPress);
    }
}