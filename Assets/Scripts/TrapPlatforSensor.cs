using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatforSensor : MonoBehaviour
{
    
    private Animator anim;
    private void Start()//获取父对象的animator
    {
        anim= this.transform.parent.gameObject.GetComponent<Animator>();
    }
    //通过触发器实现状态转换
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Collapse");
        }
    }
}
