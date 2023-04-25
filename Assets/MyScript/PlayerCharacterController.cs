using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    //========================================================================
    //SCRIPT�Q��
    public GameDataManager GameDataManager;

    //OBJ�Q��
    public GameObject OBJ_Goal;
    public GameObject[] OBJAry_PlayerChara;
    public Transform target; 
    public Animator ThisAnimator;

    //========================================================================
    //�ϐ�
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
    /// UPDATE�̕��ׂ����炷���߂̋L�^�p
    /// </summary>
    private int iPreValue_moveType=0;

    //========================================================================
    //�֐�

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

   
    private void Update()
    {

        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        //�L�����̃A�j����ύX������
        if( ( int )CommonValue.moveType_TargetPoint != iPreValue_moveType )
        {
            iPreValue_moveType = ( int )CommonValue.moveType_TargetPoint;
            ThisAnimator.SetInteger( "moveType", iPreValue_moveType );
            //Debug.Log( "moveType="+iPreValue_moveType );
        }


        //�ǂ̔j��Ɏ��s���Ă���Ƃ�
        if ( CommonValue.moveType_TargetPoint == CommonValue.MoveType_TargetPoint.FailToPass)
        {
            //Debug.Log("���s���ē|���");
            rigidBody.freezeRotation = false;
            this.transform.Rotate(8,0,0);
            this.enabled = false;
        }

        //���̈ʒu����Ŋ��A�^�[�Q�b�g����K��l�ȏ㗣��Ă���Ƃ��A
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
        //����ȊO�̎��͉��ɗ���������
        else
        {
            speed = 0.0f;
            velocity = Vector3.down* Time.deltaTime*50f;
        }

        //�Ō�ɉ������̗͂�ǉ�
        //velocity += Vector3.down * 0.1f;

        //������Ƃł����ɗ������痎�����x������������
        if (this.transform.position.y < -0.01f)
            velocity += Vector3.down * 1.8f;


        rigidBody.rotation = Quaternion.LookRotation(OBJ_Goal.transform.position);/*.FromToRotation(this.transform.position,OBJ_Goal.transform.position);*/
        rigidBody.velocity = velocity;


        //������x���ɍs���������
        if(this.transform.position.y < -5f)
        {
            this.gameObject.SetActive(false);
            GameDataManager.iCharaDisactiveCnt.Value++;
        }

    }

}


