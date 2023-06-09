using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalJudgeController : MonoBehaviour
{
    //=====================================================================================
    public Confetti Confetti;

    //=====================================================================================
    public GameObject OBJ_ResultUI;
    public GameObject OBJ_PlayingUI;

    //=====================================================================================

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerCharacter"))
        {
            OBJ_PlayingUI.SetActive(false);
            CommonValue.moveType_TargetPoint = CommonValue.MoveType_TargetPoint.Goaled;
            
            Confetti.ManualStart();  //パーティクルとかの賞賛処理も欲しい

            StartCoroutine(ResultUIActivate());
        }
    }

    IEnumerator ResultUIActivate()
    {
        yield return new WaitForSeconds(3f);
        OBJ_ResultUI.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
