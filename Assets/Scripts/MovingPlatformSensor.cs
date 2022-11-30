using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformSensor : MonoBehaviour
{
    private Transform playerDefTransform;

    private void Start()
    {
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;//��¼���ԭ������
    }
    //�����ƽ̨�Ӵ�ʱ��ʹ��ҳ�Ϊƽ̨�Ӷ���һ���ƶ�
    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.transform.parent = gameObject.transform;
            }
    }
    //�ָ���ҵĸ�����
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = playerDefTransform;
        }
    }
}
