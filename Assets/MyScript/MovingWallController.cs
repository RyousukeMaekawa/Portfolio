using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallController : MonoBehaviour
{

    //===============================================================================
    private float fCnt;

    public float fMoveDeltaX;
    private float fThisPosY;
    private float fThisPosZ;


    void Start()
    {
        fThisPosY = this.transform.position.y;
        fThisPosZ = this.transform.position.z;
    }

    void Update()
    {
        fCnt += Time.deltaTime;
        if (fCnt <=1)
        {
            fCnt = 0;
            this.transform.position += new Vector3(fMoveDeltaX, 0,0);
        }
    }
}
