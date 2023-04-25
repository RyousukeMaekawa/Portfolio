using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPointController : MonoBehaviour
{ 
    
    //=====================================================================
    //éQè∆

    [SerializeField] FloatingJoystick _FloatingJoystick;

    //=====================================================================
    //ïœêî
    private float fTargetPointMoveSpeedZ = 1f;
    private float fTargetPointMoveSpeedX = 1f;  //ï«ìÀîjé∏îséûÇ…égÇ§ó\íË

    public float fSpeed_Normal=2;
    public float fSpeed_FastSpeed=5;
    public float fSpeed_SlowSpeed=1;
    public float fSpeed_FailToPass=0;



    //=====================================================================
    //ä÷êî
    // Update is called once per frame
    void Update()
    {
        switch (CommonValue.moveType_TargetPoint)
        {
            case CommonValue.MoveType_TargetPoint.Normal:
                fTargetPointMoveSpeedZ = fSpeed_Normal;
                break;
             case CommonValue.MoveType_TargetPoint.FastSpeed:
                fTargetPointMoveSpeedZ = fSpeed_FastSpeed;
                break;
             case CommonValue.MoveType_TargetPoint.SlowSpeed:
                fTargetPointMoveSpeedZ = fSpeed_SlowSpeed;
                break;
             case CommonValue.MoveType_TargetPoint.FailToPass:
                fTargetPointMoveSpeedZ = fSpeed_FailToPass;
                fTargetPointMoveSpeedX = fSpeed_FailToPass;
                break;
             case CommonValue.MoveType_TargetPoint.Goaled:
                fTargetPointMoveSpeedZ = fSpeed_FailToPass;
                fTargetPointMoveSpeedX = fSpeed_FailToPass;
                break;
        }

        this.transform.position += Vector3.right * fTargetPointMoveSpeedX* _FloatingJoystick.Horizontal *4f* Time.deltaTime;
        this.transform.position += Vector3.forward * fTargetPointMoveSpeedZ *2f* Time.deltaTime;
    }
}
