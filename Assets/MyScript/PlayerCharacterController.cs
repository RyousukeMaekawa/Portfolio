using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    //========================================================================
    //SCRIPT参照
    public GameDataManager GameDataManager;

    //OBJ参照
    public GameObject OBJ_Goal;
    public GameObject[] OBJAry_PlayerChara;
    public Transform target; 
    public Animator ThisAnimator;

    //========================================================================
    //変数
    public float minDistance = 2.0f;
    public float maxSpeed = 5.0f;
    public float minSpeed = 1.0f;
    public float turnSpeed = 5.0f;
    public float avoidanceRadius = 1.0f;
    public LayerMask obstacleLayer;
    private Rigidbody rigidBody;
    private Vector3 velocity;
    private float speed;

    /// <summary>
    /// UPDATEの負荷を減らすための記録用
    /// </summary>
    private int iPreValue_moveType=0;


    //========================================================================
    //関数

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

   
    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        //キャラのアニメを変更したい
        if( ( int )CommonValue.moveType_TargetPoint != iPreValue_moveType )
        {
            iPreValue_moveType = ( int )CommonValue.moveType_TargetPoint;
            ThisAnimator.SetInteger( "moveType", iPreValue_moveType );
        }

        //壁の破壊に失敗しているとき
        if ( CommonValue.moveType_TargetPoint == CommonValue.MoveType_TargetPoint.FailToPass)
        {
            rigidBody.freezeRotation = false;
            this.transform.Rotate(8,0,0);
            this.enabled = false;
        }

        //床の位置より上で且つ、ターゲットから規定値以上離れているとき、
        else if ((distance > minDistance)&&(this.transform.position.y >= 0f))
        {
            float speedFactor = Mathf.InverseLerp(minDistance, 0.0f, distance);
            speed = Mathf.Lerp(minSpeed, maxSpeed, speedFactor);

            direction.Normalize();

            // Avoidance
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, avoidanceRadius, obstacleLayer);
            Vector3 avoidanceMove = Vector3.zero;

            for (int i = 0; i < hitColliders.Length; i++)
            {
                Transform obstacle = hitColliders[i].transform;
                Vector3 avoidanceDirection = transform.position - obstacle.position;
                avoidanceMove += avoidanceDirection.normalized / avoidanceDirection.magnitude;
            }

            avoidanceMove.Normalize();

            Vector3 desiredVelocity = (direction + avoidanceMove).normalized * speed;
            desiredVelocity.y = -5f;
            velocity = Vector3.Lerp(velocity, desiredVelocity, Time.deltaTime * turnSpeed);
        }
        //それ以外の時は下に落下させる
        else
        {
            speed = 0.0f;
            velocity = Vector3.down* Time.deltaTime*50f;
        }

        //ちょっとでも下に落ちたら落下速度を加速させる
        if (this.transform.position.y < -0.01f) velocity += Vector3.down * 1.8f;

        rigidBody.rotation = Quaternion.LookRotation(OBJ_Goal.transform.position);/*.FromToRotation(this.transform.position,OBJ_Goal.transform.position);*/
        rigidBody.velocity = velocity;

        //ある程度下に行ったら消す
        if(this.transform.position.y < -5f)
        {
            this.gameObject.SetActive(false);
            GameDataManager.iCharaDisactiveCnt.Value++;
        }
    }
}
