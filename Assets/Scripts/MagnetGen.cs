using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 本脚本实现：
/// 1.存储物体产生的磁场的数据，以供调用
/// 2.本脚本应该挂在MagnetGen子物体上，不应挂在父物体上，以便确认sensor进入的是磁场而不是其他trigger
/// 磁性控制（通过磁场产生作用力） --用胶囊碰撞体模拟磁场，超出碰撞体范围，磁场失效
/// 3.MagnetGen的tag代表产生的磁场极性
/// 4.根据磁性改变物体的颜色
/// </summary>
public class MagnetGen : MonoBehaviour
{
    public float strength; // 产生的磁场强度，游戏内可变
}
