using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //===============================================================
    //OBJ��
    public Transform Tr_TargetPoint;
    private Vector3 offset;      //���΋����擾�p


    //===============================================================
    //�ϐ�
    public int iOffsetY = 10;
    public int iOffsetZ = -10;

    //===============================================================
    //�֐�

    void Start()
    {
        // MainCamera(�������g)��player�Ƃ̑��΋��������߂�
        offset = new Vector3( 0, iOffsetY, iOffsetZ );
    }

    // Update is called once per frame
    void Update()
    {
        if ( CommonValue.moveType_TargetPoint == CommonValue.MoveType_TargetPoint.FastSpeed )
        {
            //�ړ����x�ɍ��킹�ăJ�����̈ړ����x���ς���ׂ���
        }

        //Debug.Log("�X�V�����L�e��;iCharaNum_MaxPosZ=" + iCharaNum_MaxPosZ);
        this.transform.position = Tr_TargetPoint.position + offset;

        //�J�����̊p�x�͌Œ�
        this.transform.rotation = Quaternion.Euler( 20, 0, 0 );
    }
}
