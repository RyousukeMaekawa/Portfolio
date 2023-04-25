using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassagePanelController : MonoBehaviour
{
    //===============================================================================
    /// <summary>
    /// ①＋５②＋１０③×１．５みたいな感じで
    /// </summary>
    [SerializeField]
    private int iPositiveGimmickNum;

    /// <summary>
    /// ギミックごとに倍率を設定する
    /// </summary>
    [SerializeField]
    private float fMultiplyer = 1.5f;

    /// <summary>
    /// オブジェクト名記録用
    /// </summary>
    private string[] sOBJName_PassedChara = new string[10];

    /// <summary>
    /// 通過したOBJの数
    /// </summary>
    private int iOBJCnt_PassedChara = 0;

    //===============================================================================
    /// <summary>
    /// すりぬけたとき
    /// すりぬけたオブジェクトを取得し拡大操作をする
    /// </summary>
    public void  OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerCharacter"))
        {
            //既に通過したキャラクタだった場合抜ける
            for (int i=0;i<10;i++)
            {
                if (sOBJName_PassedChara[i] == collision.gameObject.name)
                {
                    return;
                }
            }

            //Debug.Log("すりぬけを検知しました。");
            sOBJName_PassedChara[iOBJCnt_PassedChara] = collision.gameObject.name;
            iOBJCnt_PassedChara++;

            collision.gameObject.transform.localScale = collision.gameObject.transform.localScale * fMultiplyer;
        }

        //ギミックの種類ごとで倍率を分岐させる
    }

}
