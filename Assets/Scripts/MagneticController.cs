using UnityEngine;
/// <summary>
/// 本脚本实现
/// 1.磁性控制（通过磁场产生作用力） --用胶囊碰撞体模拟磁场，超出碰撞体范围，磁场失效
/// 注：磁性作用方式，Fe 铁磁性，能被N和S吸引,Non清空磁力效果
/// 2.此脚本应该挂载在MagnetSensor物体下，父物体才是真正受力的物体
/// </summary>
public class MagneticController : MonoBehaviour
{
    public static float mu0 = 10.0f; // 磁常数
    public float strength; // 磁场强度，游戏内可变
    Rigidbody2D rb2D;
    string forceType;
    public float magnRate; // 磁导率
    private void Awake()
    {
        rb2D = transform.parent.GetComponent<Rigidbody2D>(); // 获取父物体的Rigidbody2D
    }

    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if ((this.tag == "N" && other.CompareTag("N")) || (this.tag == "S" && other.CompareTag("S")))
            forceType = "reject"; // 同性相斥
        else if ((this.tag == "N" && other.CompareTag("S")) || (this.tag == "S" && other.CompareTag("N")))
            forceType = "attract"; // 异性相吸
        else if ((this.tag == "Fe") && (other.CompareTag("N") || other.CompareTag("S"))) forceType = "other_attract_this"; // 对方吸引自己
        else forceType = null; // 碰撞到非磁性物体：即tag不属于{N,S,Fe}的,重置forceType为null
        switch (forceType)
        {
            case "reject":
                {
                    Rigidbody2D other_rb2D = other.transform.parent.GetComponent<Rigidbody2D>(); // 获取碰撞对象的父物体的Rigidbody2D,
                    Vector2 direction = other_rb2D.position - rb2D.position; // 两个物体的距离向量(方向从本物体指向碰撞物体)
                    // mu是由每帧间隔时间，磁铁的磁场强度，目标物体的磁导率以及磁常数共同决定的一个磁力系数
                    float mu = Time.fixedDeltaTime * other.GetComponent<MagneticController>().strength * mu0 * magnRate;
                    // 计算自己的受力
                    Vector2 f = -direction.normalized * mu * 40f /
                    (Mathf.Pow(Mathf.Max(direction.magnitude, 1.7f), 3)); // f的模值就是力的大小
                    rb2D.AddForce(f); // AddForce方法是直接连续的对物体施加力，不用管position的问题，系统会自己更新
                    break;
                }
            case "attract":
                {
                    Rigidbody2D other_rb2D = other.transform.parent.GetComponent<Rigidbody2D>(); // 获取碰撞对象的父物体的Rigidbody2D,
                    Vector2 direction = other_rb2D.position - rb2D.position; // 两个物体的距离向量(方向从本物体指向碰撞物体)
                    // mu是由每帧间隔时间，磁铁的磁场强度，目标物体的磁导率以及磁常数共同决定的一个磁力系数
                    float mu = Time.fixedDeltaTime * other.GetComponent<MagneticController>().strength * mu0 * magnRate;
                    // 计算自己的受力
                    Vector2 f = direction.normalized * mu *
                    (Mathf.Pow(Mathf.Min(direction.magnitude, 2.0f), 3));
                    rb2D.AddForce(f);
                    break;
                }
            /* case "other_attract_this": // 铁磁性先不做
                {
                    Rigidbody2D other_rb2D = other.transform.parent.GetComponent<Rigidbody2D>(); // 获取碰撞对象的父物体的Rigidbody2D,
                    Vector2 direction = other_rb2D.position - rb2D.position; // 两个物体的距离向量(方向从本物体指向碰撞物体)
                    // mu是由每帧间隔时间，磁铁的磁场强度，目标物体的磁导率以及磁常数共同决定的一个磁力系数
                    float mu = Time.fixedDeltaTime * other.GetComponent<MagneticController>().strength * mu0 * magnRate;
                    Vector2 f = direction.normalized * mu /
                    (Mathf.Pow(Mathf.Max(direction.magnitude, 0.2f), 3));
                    rb2D.AddForce(f);
                    if (direction.magnitude < 1.0f) other_rb2D.AddForceAtPosition(-f, other_rb2D.position); // 给对象物体一个固定点力，防止他被吸引力击飞
                    break;
                } */
            default: break; // 为null时
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        forceType = null;
    }
}
