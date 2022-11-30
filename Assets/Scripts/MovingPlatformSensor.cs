using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformSensor : MonoBehaviour
{
    private Transform playerDefTransform;

    private void Start()
    {
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;//记录玩家原父对象
    }
    //玩家与平台接触时，使玩家成为平台子对象，一起移动
    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.transform.parent = gameObject.transform;
            }
    }
    //恢复玩家的父对象
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = playerDefTransform;
        }
    }
}
