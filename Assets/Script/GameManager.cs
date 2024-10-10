using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UIMG;

    [SerializeField] private bool playerTurn;
    private int playerMoveCounter;

    [SerializeField] public int PLHP;
    [SerializeField] public int PL2HP;
    [SerializeField] public int PLSP;
    public GameObject PlayerObj;

    public int ENHP;
    public int EN2HP;
    public GameObject EnemyObj;
    void Start()
    {
        playerTurn = true;
        playerMoveCounter = 0;

        PLHP = UIMG.playerHp;
        PLSP = UIMG.playerSp;

        PL2HP = UIMG.player2Hp;

        ENHP = UIMG.enemyHp;
        EN2HP = UIMG.enemy2Hp;
    }

    public void PlayerTurnEnd()
    {
        playerMoveCounter = 1;
        playerTurn = false;
        if (playerTurn == false)
        {
            UIMG.EnemyTurn();
            if (playerMoveCounter == 1 && PLHP >= 0 || PL2HP >= 0)
            {
                UIMG.Enemyattack();
            }
        }
    }

    public void EnemyTurnEnd()
    {
        playerMoveCounter = 0;
        playerTurn = true;
        if (playerTurn == true)
        {
            if (playerMoveCounter == 0 && PLHP >= 0 || PL2HP >= 0)
            {
                UIMG.PlayerTurn();
            }
        }
    }
}
