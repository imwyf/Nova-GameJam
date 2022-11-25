using UnityEngine;
/// <summary>
/// 本脚本实现
/// 注：磁性作用方式，Fe 铁磁性，能被N和S吸引,Non清空磁力效果
/// 1.此脚本应该挂载在MagnetSensor物体下，父物体才是真正受力的物体
/// 2.当本物体进入其他物体产生的磁场（碰撞体），才会受到相应磁力
/// 3.MagnetSensor的tag代表物体自己的极性
/// </summary>
public class MagnetSensor : MonoBehaviour
{
    Rigidbody2D rb2D;
    string forceType;
    public float magnRate; // 本物体磁导率
    private void Awake()
    {
        rb2D = transform.parent.GetComponent<Rigidbody2D>(); // 获取父物体的Rigidbody2D
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name != "MagnetGen") return; // 当sensor碰撞的对象是磁场才产生磁力
        var other_tag = other.tag;

        if ((this.tag == "N" && other_tag == "N") || (this.tag == "S" && other_tag == "S"))
            forceType = "reject"; // 同性相斥
        else if ((this.tag == "N" && other_tag == "S") || (this.tag == "S" && other_tag == "N"))
            forceType = "attract"; // 异性相吸
        else if (this.tag == "Fe" && (other_tag == "N" || other_tag == "S")) forceType = "other_attract_this"; // 对方吸引自己
        else forceType = null; // 碰撞到非磁性物体：即tag不属于{N,S,Fe}的,重置forceType为null
        switch (forceType)
        {
            case "reject":
                {
                    Vector2 direction = other.transform.position - this.transform.position; // 两个物体的距离向量(方向从本物体指向碰撞物体)
                    // mu是由每帧间隔时间，磁铁的磁场强度，目标物体的磁导率以及磁常数共同决定的一个磁力系数
                    float mu = Time.fixedDeltaTime * other.GetComponent<MagnetGen>().strength * 10.0f * magnRate;
                    // 计算自己的受力
                    Vector2 f = -direction.normalized * mu * 40f /
                    (Mathf.Pow(Mathf.Max(direction.magnitude, 1.7f), 3)); // f的模值就是力的大小
                    rb2D.AddForce(f); // AddForce方法是直接连续的对物体施加力，不用管position的问题，系统会自己更新
                    break;
                }
            case "attract":
                {
                    Vector2 direction = other.transform.position - this.transform.position; // 两个物体的距离向量(方向从本物体指向碰撞物体)
                    // mu是由每帧间隔时间，磁铁的磁场强度，目标物体的磁导率以及磁常数共同决定的一个磁力系数
                    float mu = Time.fixedDeltaTime * other.GetComponent<MagnetGen>().strength * 10.0f * magnRate;
                    // 计算自己的受力
                    Vector2 f = direction.normalized * mu *
                    (Mathf.Pow(Mathf.Min(direction.magnitude, 2.0f), 3));
                    rb2D.AddForce(f);
                    break;
                }
            case "other_attract_this": // 铁磁性先不做
                {
                    Rigidbody2D other_rb2D = other.transform.parent.GetComponent<Rigidbody2D>(); // 获取碰撞对象的父对象的Rigidbody2D,
                    Vector2 direction = other_rb2D.position - rb2D.position; // 两个物体的距离向量(方向从本物体指向碰撞物体)
                    // mu是由每帧间隔时间，磁铁的磁场强度，目标物体的磁导率以及磁常数共同决定的一个磁力系数
                    float mu = Time.fixedDeltaTime * other.GetComponent<MagnetGen>().strength * 10.0f * magnRate;
                    Vector2 f = direction.normalized * mu /
                    (Mathf.Pow(Mathf.Max(direction.magnitude, 1.0f), 3));
                    rb2D.AddForce(f);
                    if (direction.magnitude < 1.0f) other_rb2D.AddForceAtPosition(-f, other_rb2D.position); // 给对象物体一个固定点力，防止他被吸引力击飞
                    break;
                }
            default: break; // 为null时
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        forceType = null;
    }
}
