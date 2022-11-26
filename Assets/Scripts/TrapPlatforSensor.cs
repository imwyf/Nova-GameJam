using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatforSensor : MonoBehaviour
{
    
    private Animator anim;
    private void Start()//��ȡ�������animator
    {
        anim= this.transform.parent.gameObject.GetComponent<Animator>();
    }
    //ͨ��������ʵ��״̬ת��
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Collapse");
        }
    }
}
