using UnityEngine;
/// <summary>
/// 本脚本实现：
/// 1.移动
/// 2.跳跃(todo:这里需要地面检测)
/// 3.动画效果
/// </summary>
public class PlayerController1 : MonoBehaviour
{
    // --------移动--------
    Rigidbody2D rb2D;
    float moveDirection;
    public float maxSpeed; // 横向移动最大速度
    public float h_force; // 按键时，横向力大小
    public float v_force; // 跳跃时，纵向的力
    // ---------地面检测----------
    bool isGround = false;
    GroundSensor gs;
    bool isJump;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        gs = transform.GetChild(0).GetComponent<GroundSensor>();
    }
    void Update()
    {
        // ---------地面检测----------
        isGround = gs.isGround;
        // ---------检测移动和跳跃---------
        moveDirection = GetMoveDirection();
        if (Input.GetKeyDown(KeyCode.W) && isGround) isJump = true;
    }
    private void FixedUpdate()
    {
        // ----------移动和跳跃-----------
        Move(moveDirection);
        if (isJump)
        {
            Jump();
            isJump = false;
        }
    }
    private float GetMoveDirection()
    {
        // ----------检测移动-----------
        // GetAxisRaw可以实现松开按键时，值立刻变为0
        float horizontal = Input.GetAxisRaw("Horizontal1");
        // float vertical = Input.GetAxisRaw("Vertical");  不需要纵向移动
        return horizontal;
    }
    private void Move(float moveDirection)
    {
        if (!Mathf.Approximately(moveDirection, 0.0f) && isGround && rb2D.velocity.magnitude <= maxSpeed) // 在地上才能走
            rb2D.AddForce(new Vector2(moveDirection * h_force, 0.0f));
    }
    private void Jump()
    {
        rb2D.AddForce(Vector2.up * v_force, ForceMode2D.Impulse);
    }
}
