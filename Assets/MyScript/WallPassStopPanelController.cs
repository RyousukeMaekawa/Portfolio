using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPassStopPanelController : MonoBehaviour
{
    public UIManager UIManager;

    /// <summary>
    /// 判定不合格状態で壁に接触したとき
    ///・キャラが壁にあたり倒れる
    ///・ゲームオーバーUIの表示
    /// </summary>
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerCharacter"))
        {
            CommonValue.moveType_TargetPoint = CommonValue.MoveType_TargetPoint.FailToPass;
            StartCoroutine(UIManager.ShowGameOver(1f));
        }
    }
}
