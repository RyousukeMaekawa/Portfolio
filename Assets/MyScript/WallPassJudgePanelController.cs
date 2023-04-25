using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPassJudgePanelController : MonoBehaviour
{
    //==============================================================================================
    /// <summary>
    /// 通過停止用のパネル
    /// </summary>
    public GameObject OBJ_PassStopPanel;

    [Header("壁突破の合格基準値")]
    /// <summary>
    /// 壁突破の合格基準値
    /// </summary>
    public float fPassingSize=1;


    //==============================================================================================
    /// <summary>
    /// 接触したときとき
    /// </summary>
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerCharacter"))
        {
            //壁まで全力疾走でぶつかる
            CommonValue.moveType_TargetPoint = CommonValue.MoveType_TargetPoint.FastSpeed;

            //基準値をクリアしていたら
            if (collision.gameObject.transform.localScale.y >= fPassingSize)
            {
                OBJ_PassStopPanel.SetActive(false);
                //Debug.Log("壁突破判定：合格");
            }
            //基準値をクリアしていなければ
            else
            {
                //Debug.Log("壁突破判定：不合格");
            }
        }
    }

}
