using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAttackButton : MonoBehaviour
{
    public GameManager GM;
    public UIManager UIMG;
    public void OnClickAttackButton()
    {
        //UIMGのPushAttackButtonに後々変更
        UIMG.PushAttackButton();
        //gm.AttackEnemy();
        //gm.PlayerTurnEnd();
    }
}
