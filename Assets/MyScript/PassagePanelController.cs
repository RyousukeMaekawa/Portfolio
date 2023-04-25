using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassagePanelController : MonoBehaviour
{
    //===============================================================================
    /// <summary>
    /// �@�{�T�A�{�P�O�B�~�P�D�T�݂����Ȋ�����
    /// </summary>
    [SerializeField]
    private int iPositiveGimmickNum;

    /// <summary>
    /// �M�~�b�N���Ƃɔ{����ݒ肷��
    /// </summary>
    [SerializeField]
    private float fMultiplyer = 1.5f;

    /// <summary>
    /// �I�u�W�F�N�g���L�^�p
    /// </summary>
    private string[] sOBJName_PassedChara = new string[10];

    /// <summary>
    /// �ʉ߂���OBJ�̐�
    /// </summary>
    private int iOBJCnt_PassedChara = 0;

    //===============================================================================
    /// <summary>
    /// ����ʂ����Ƃ�
    /// ����ʂ����I�u�W�F�N�g���擾���g�呀�������
    /// </summary>
    public void  OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerCharacter"))
        {
            //���ɒʉ߂����L�����N�^�������ꍇ������
            for (int i=0;i<10;i++)
            {
                if (sOBJName_PassedChara[i] == collision.gameObject.name)
                {
                    return;
                }
            }

            //Debug.Log("����ʂ������m���܂����B");
            sOBJName_PassedChara[iOBJCnt_PassedChara] = collision.gameObject.name;
            iOBJCnt_PassedChara++;

            collision.gameObject.transform.localScale = collision.gameObject.transform.localScale * fMultiplyer;
        }

        //�M�~�b�N�̎�ނ��ƂŔ{���𕪊򂳂���
    }

}
