using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private bool playerTurn;
    private int playerMoveCounter;

    Player playercs;
    public int PLHP;
    public int PLSP;
    private GameObject PlayerObj;

    Enemy enemycs;
    public int ENHP;
    private GameObject EnemyObj;
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = true;
        playerMoveCounter = 0;
    }

    public void PlayerTurnEnd()
    {
        playerMoveCounter = 1;
        playerTurn = false;
    }

    public void EnemyTurnEnd()
    {
        playerMoveCounter = 0;
        playerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTurn == true)
        {
            playercs = this.gameObject.GetComponent<Player>();
            PLHP = playercs.playerHp;
            PLSP = playercs.playerSp;
            if(playerMoveCounter == 0 || PLHP > 0)
            {
                UIManager.instance.PlayerTurn();
            }
        }
        if(playerTurn == false)
        {
            enemycs = this.gameObject.GetComponent<Enemy>();
            ENHP = enemycs.enemyHp;
            if(playerMoveCounter == 1 || PLHP > 0)
            {
                UIManager.instance.EnemyTurn();
                enemycs.AttackPlayer();
            }
        }
    }
}
