using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameDataManager : MonoBehaviour
{

    public UIManager UIManager;
    
    /// <summary>
    /// �����Ă���L�����̃J�E���g �Q�[���I�[�o�[����p�Ɏg��
    /// </summary>
    public ReactiveProperty<int> iCharaDisactiveCnt = new ReactiveProperty<int>(0);

    private void Start()
    {
        CommonValue.moveType_TargetPoint = CommonValue.MoveType_TargetPoint.Normal;

        iCharaDisactiveCnt
            .Where(x => x >= 10)
            .Subscribe(x=>StartCoroutine(UIManager.ShowGameOver()));


        iCharaDisactiveCnt
            .Pairwise()
            .Where(x => x.Previous <= x.Current)
            .Subscribe(x=>UIManager.SetCharacterActiveCnt(x.Current));
    }

}
