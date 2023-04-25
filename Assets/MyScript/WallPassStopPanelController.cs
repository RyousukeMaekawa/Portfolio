using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPassStopPanelController : MonoBehaviour
{
    public UIManager UIManager;

    /// <summary>
    /// �ڐG�����Ƃ��Ƃ�
    /// </summary>
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerCharacter"))
        {
            //�ǂɂ�����|���悤�ɂ�����
            CommonValue.moveType_TargetPoint = CommonValue.MoveType_TargetPoint.FailToPass;

            Debug.Log("�Ǔ˔j���s");
            StartCoroutine(UIManager.ShowGameOver(1f));
        }
    }

}
