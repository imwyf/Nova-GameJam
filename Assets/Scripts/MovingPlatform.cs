using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] movePos;//��¼�۷���

    private int i;
    private Transform playerDefTransform;
    void Start()
    {
        i = 1;
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;//��¼���ԭ������
    }

    //��Update��ʵ���ƶ�
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position,movePos[i].position) < 0.1f)
        {
            if(waitTime<0.0f)
            {
                if(i==0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }
    //�����ƽ̨�Ӵ�ʱ��ʹ��ҳ�Ϊƽ̨�Ӷ���һ���ƶ�
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = gameObject.transform;
        }
    }


    //�ָ���ҵĸ�����
    private void OnCollisionExit2D(Collision2D other)
    {
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.transform.parent = playerDefTransform;
            }
        }
    }

}
