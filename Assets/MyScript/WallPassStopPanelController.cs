using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPassStopPanelController : MonoBehaviour
{
    public UIManager UIManager;

    /// <summary>
    /// ê⁄êGÇµÇΩÇ∆Ç´Ç∆Ç´
    /// </summary>
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerCharacter"))
        {
            //ï«Ç…Ç†ÇΩÇËì|ÇÍÇÈÇÊÇ§Ç…ÇµÇΩÇ¢
            CommonValue.moveType_TargetPoint = CommonValue.MoveType_TargetPoint.FailToPass;

            Debug.Log("ï«ìÀîjé∏îs");
            StartCoroutine(UIManager.ShowGameOver(1f));
        }
    }

}
