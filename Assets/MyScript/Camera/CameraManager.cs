using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //==============================================================================================
    [Tooltip("�L������ǂ������郁�C���J����")]
    public GameObject OBJ_MainCamera;
    [Tooltip("�S�[�����ӂŎg�p����J����")]
    public GameObject OBJ_SubCamera;

    //==============================================================================================

    //��x�ł�����|�C���g�ʉ߂������������ړ����[�h�ɓ��������𔻒�
    private bool isOnceChangedTo_FastSpeed=false;


    //==============================================================================================
    void Start()
    {
        isOnceChangedTo_FastSpeed = false;
    }

  

    // Update is called once per frame
    void Update()
    {
        //�ǂꂩ�̃L�����������ړ����[�h�ɂȂ����Ƃ��A��񂾂���������������
        if (( !isOnceChangedTo_FastSpeed )&&(CommonValue.moveType_TargetPoint == CommonValue.MoveType_TargetPoint.FastSpeed))
        {
            Debug.Log("�J�����ύX");
            isOnceChangedTo_FastSpeed = true;
            StartCoroutine( IE_CameraChange() );
        }
    }

    IEnumerator IE_CameraChange()
    {
        yield return new WaitForSeconds(0.7f);
        OBJ_SubCamera.SetActive( true );

    }
}
