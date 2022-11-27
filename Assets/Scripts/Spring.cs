using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
/// <summary>
/// 本脚本实现：
/// 1.控制不带磁性的弹簧，模拟现实弹簧
/// 
/// </summary>
public class Spring : MonoBehaviour
{
    #region Fields
    public SpriteShapeController shapeController;
    public GameObject board; // 弹簧顶板
    public GameObject body; // 弹簧节点
    Vector2 board_start_pos;
    Vector2 board_current_pos;
    Vector2 body_pos;
    public float offset; // 两顶点距离顶板中心的偏移
    #endregion

    #region MonoBehaviour Callbacks
    private void Start()
    {
        // 记录开始时顶板和节点位置
        board_start_pos = board.transform.localPosition;
        body_pos = body.transform.localPosition;
    }
    private void Update()
    {
        UpdatePos();
    }
    #endregion

    #region privateMethods 
    void UpdatePos()
    {
        // 获取弹簧顶板位置
        board_current_pos = board.transform.localPosition;
        // 设置顶点位置
        Vector2 pos0 = new Vector2(board_current_pos.x - offset, body_pos.y);
        Vector2 pos1 = new Vector2(board_current_pos.x - offset, board_current_pos.y);
        Vector2 pos2 = new Vector2(board_current_pos.x + offset, board_current_pos.y);
        Vector2 pos3 = new Vector2(board_current_pos.x + offset, body_pos.y);

        shapeController.spline.SetPosition(0, pos0);
        shapeController.spline.SetPosition(1, pos1);
        shapeController.spline.SetPosition(2, pos2);
        shapeController.spline.SetPosition(3, pos3);

        #endregion
    }
}