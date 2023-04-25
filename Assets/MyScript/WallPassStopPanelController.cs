using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPassStopPanelController : MonoBehaviour
{
    public UIManager UIManager;

    /// <summary>
    /// 接触したときとき
    /// </summary>
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerCharacter"))
        {
            //壁にあたり倒れるようにしたい
            CommonValue.moveType_TargetPoint = CommonValue.MoveType_TargetPoint.FailToPass;

            Debug.Log("壁突破失敗");
            StartCoroutine(UIManager.ShowGameOver(1f));
        }
    }

}
