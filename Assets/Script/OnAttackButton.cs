using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAttackButton : MonoBehaviour
{
    public GameManager GM;
    public UIManager UIMG;
    public void OnClickAttackButton()
    {
        UIMG.minusEnemyHp();
        //gm.AttackEnemy();
        //gm.PlayerTurnEnd();
    }
}
