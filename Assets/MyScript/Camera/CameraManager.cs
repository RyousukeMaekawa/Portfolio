using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //==============================================================================================
    [Tooltip("キャラを追いかけるメインカメラ")]
    public GameObject OBJ_MainCamera;
    [Tooltip("ゴール周辺で使用するカメラ")]
    public GameObject OBJ_SubCamera;

    //==============================================================================================

    //一度でも判定ポイント通過したか＝高速移動モードに入ったかを判定
    private bool isOnceChangedTo_FastSpeed=false;


    //==============================================================================================
    void Start()
    {
        isOnceChangedTo_FastSpeed = false;
    }

  

    // Update is called once per frame
    void Update()
    {
        //どれかのキャラが高速移動モードになったとき、一回だけだけ処理したい
        if (( !isOnceChangedTo_FastSpeed )&&(CommonValue.moveType_TargetPoint == CommonValue.MoveType_TargetPoint.FastSpeed))
        {
            Debug.Log("カメラ変更");
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
