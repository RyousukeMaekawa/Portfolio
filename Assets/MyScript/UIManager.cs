using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// MVPデザインパターンを目指す
/// </summary>
public class UIManager : MonoBehaviour
{
    public GameObject OBJ_GameOverUI;

    public TextMeshProUGUI Text_CharaActiveCnt;

    public void OnClick_QuitGame()
    {
        RestartGame();
    }

    public void OnClick_ResumeGame()
    {
        RestartGame();
    }

    public IEnumerator ShowGameOver(float fDelay=0f) 
    {
        yield return new WaitForSeconds(fDelay);
        OBJ_GameOverUI.SetActive(true);
    }


    /// <summary>
    /// 残存しているキャラの数を更新
    /// </summary>
    /// <param name="iCharaCnt"></param>
    public void SetCharacterActiveCnt(int iCharaDisactiveCnt)
    {
        Text_CharaActiveCnt.text = "Remain : "+(10- iCharaDisactiveCnt).ToString();
    }



    private void RestartGame()
    {
        Time.timeScale = 1.0f; //時間起動
        SceneManager.LoadScene(0); //シーンの再読み込み
    }


}
