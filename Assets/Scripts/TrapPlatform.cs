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
    //������֡�¼����ã�ʹ��ײ����ʧ
    void DisableBoxCollider2D()
    {
       bx2d.enabled = false;
    }
    //������֡�¼����ã��ݻ���Ϸ����
    void DestroyTrapPlatform()
    {
        Destroy(gameObject);
    }
}
