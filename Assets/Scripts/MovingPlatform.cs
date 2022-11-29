using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] movePos;//记录折返点

    private int i;
    private Transform playerDefTransform;
    void Start()
    {
        i = 1;
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;//记录玩家原父对象
    }

    //在Update内实现移动
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
    //玩家与平台接触时，使玩家成为平台子对象，一起移动
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = gameObject.transform;
        }
    }


    //恢复玩家的父对象
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
