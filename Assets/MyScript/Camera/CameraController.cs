using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //===============================================================
    //OBJ等
    public Transform Tr_TargetPoint;
    private Vector3 offset;      //相対距離取得用

    //===============================================================
    //変数
    public int iOffsetY = 10;
    public int iOffsetZ = -10;

    //===============================================================
    //関数

    void Start()
    {
        // MainCamera(自分自身)とplayerとの相対距離を求める
        offset = new Vector3( 0, iOffsetY, iOffsetZ );
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Tr_TargetPoint.position + offset;
        this.transform.rotation = Quaternion.Euler( 20, 0, 0 );
    }
}
