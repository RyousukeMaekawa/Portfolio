using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ʂŎg�p����ϐ����������Œ�`���Ă���
/// </summary>
public static class CommonValue 
{
    public static MoveType_TargetPoint moveType_TargetPoint = MoveType_TargetPoint.Normal;

    public enum MoveType_TargetPoint
    {
        Normal,�@�@ //�ʏ푖�s
        FastSpeed,  //����̈�ʉ߁`�Ǔ˔j
        SlowSpeed,  //�Ǔ˔j�`�S�[������
        FailToPass,
        Goaled
    }

}
