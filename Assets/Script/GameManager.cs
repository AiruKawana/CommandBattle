using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UiMg;

    [SerializeField] private bool playerTurn;
    private int playerMoveCounter;

    Player playercs;
    public int PLHP;
    public int PLSP;
    public GameObject PlayerObj;

    Enemy enemycs;
    public int ENHP;
    public GameObject EnemyObj;

    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = true;
        playerMoveCounter = 0;

        playercs = this.gameObject.GetComponent<Player>();
      // PLHP = playercs.playerHp;
       //PLSP = playercs.playerSp;

        enemycs = this.gameObject.GetComponent<Enemy>();
       // ENHP = enemycs.enemyHp;
    }

    public void AttackEnemy()
    {
        damage = Random.Range(1, 15);
        if(damage > 1)
        {
            //“G‚ÌHP - Damage‚Ì‹Lq
            damage = 0;
        }
        Debug.Log(damage);
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
            if(playerMoveCounter == 0 || PLHP > 0)
            {
                UiMg.PlayerTurn();
            }
        }
        if(playerTurn == false)
        {
            UiMg.EnemyTurn();
            if(playerMoveCounter == 1 || PLHP > 0)
            {
                enemycs.AttackPlayer();
            }
        }
    }
}
