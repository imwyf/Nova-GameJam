using UnityEngine;
using UnityEngine.UI;

public class ShowMagnet : MonoBehaviour
{
    public Transform father;
    public float offset;
    public Text text;
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        //把人物的坐标转化到屏幕坐标
        var fatherScreenPos = cam.WorldToScreenPoint(father.position);
        //再把人物坐标Y加一个高度给到人物
        text.rectTransform.position = new Vector3(fatherScreenPos.x, fatherScreenPos.y + offset, fatherScreenPos.z);
        text.text = father.tag;
    }
}
