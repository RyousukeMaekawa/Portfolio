using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPassJudgePanelController : MonoBehaviour
{
    //==============================================================================================
    /// <summary>
    /// �ʉߒ�~�p�̃p�l��
    /// </summary>
    public GameObject OBJ_PassStopPanel;

    [Header("�Ǔ˔j�̍��i��l")]
    /// <summary>
    /// �Ǔ˔j�̍��i��l
    /// </summary>
    public float fPassingSize=1;


    //==============================================================================================
    /// <summary>
    /// �ڐG�����Ƃ��Ƃ�
    /// </summary>
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerCharacter"))
        {
            //�ǂ܂őS�͎����łԂ���
            CommonValue.moveType_TargetPoint = CommonValue.MoveType_TargetPoint.FastSpeed;

            //��l���N���A���Ă�����
            if (collision.gameObject.transform.localScale.y >= fPassingSize)
            {
                OBJ_PassStopPanel.SetActive(false);
                //Debug.Log("�Ǔ˔j����F���i");
            }
            //��l���N���A���Ă��Ȃ����
            else
            {
                //Debug.Log("�Ǔ˔j����F�s���i");
            }
        }
    }

}
