using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UIMG;

    [SerializeField] private bool playerTurn;
    private int playerMoveCounter;

    public Player playercs;
    public int PLHP;
    public int PLSP;
    public GameObject PlayerObj;

     public Enemy enemycs;
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
        //playercs = this.gameObject.GetComponent<Player>();
        // PLHP = playercs.playerHp;
        //PLSP = playercs.playerSp;

        //enemycs = this.gameObject.GetComponent<Enemy>();
        // ENHP = enemycs.enemyHp;
    }

    //UIマネージャーの管轄の疑いにつき、一旦コメントアウト
    //public void AttackEnemy()
    //{
       // damage = Random.Range(x, y);
        //if(damage > 1)
        //{
            //敵のHP - Damageの記述
            //damage = 0;
        //}
        //Debug.Log(damage);
    //}

    public void PlayerTurnEnd()
    {
        playerMoveCounter = 1;
        playerTurn = false;
        if (playerTurn == false)
        {
            UIMG.EnemyTurn();
            if (playerMoveCounter == 1 && PLHP > 0)
            {
                enemycs.AttackPlayer();
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
