using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    private BoxCollider2D bx2d;
    void Start()
    {
        bx2d = GetComponent<BoxCollider2D>();
    }
    //供动画帧事件调用，使碰撞箱消失
    void DisableBoxCollider2D()
    {
       bx2d.enabled = false;
    }
    //供动画帧事件调用，摧毁游戏对象
    void DestroyTrapPlatform()
    {
        Destroy(gameObject);
    }
}
