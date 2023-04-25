using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 共通で使用する変数等をここで定義しておく
/// </summary>
public static class CommonValue 
{
    public static MoveType_TargetPoint moveType_TargetPoint = MoveType_TargetPoint.Normal;

    public enum MoveType_TargetPoint
    {
        Normal,　　 //通常走行
        FastSpeed,  //判定領域通過～壁突破
        SlowSpeed,  //壁突破～ゴール判定
        FailToPass,
        Goaled
    }

}
