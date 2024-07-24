using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAttackButton : MonoBehaviour
{
    public GameManager gm;
    public UIManager UIMg;
    public void OnClickAttackButton()
    {
        UIMg.AttackEnemy();
        //gm.AttackEnemy();
        //gm.PlayerTurnEnd();
    }
}
