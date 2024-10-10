using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UIMG;

    [SerializeField] private bool playerTurn;
    private int playerMoveCounter;

    [SerializeField] public int PLHP;
    [SerializeField] public int PLSP;
    public GameObject PlayerObj;

    public int ENHP;
    public GameObject EnemyObj;

    //private int damage;
    //private int x = 1;
    //private int y = 15;
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = true;
        playerMoveCounter = 0;

        PLHP = UIMG.playerHp;
        PLSP = UIMG.playerSp;
        ENHP = UIMG.enemyHp;
    }

    public void PlayerTurnEnd()
    {
        playerMoveCounter = 1;
        playerTurn = false;
        if (playerTurn == false)
        {
            UIMG.EnemyTurn();
            if (playerMoveCounter == 1 && PLHP > 0)
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
            if (playerMoveCounter == 0 && PLHP > 0)
            {
                UIMG.PlayerTurn();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
