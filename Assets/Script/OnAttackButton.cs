using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAttackButton : MonoBehaviour
{
    public GameManager gm;
    public void OnClickAttackButton()
    {
        gm.AttackEnemy();
        //gm.PlayerTurnEnd();
    }
}
