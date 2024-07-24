using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UiMg;

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

        PLHP = 100;
        PLSP = 25;
        ENHP = 100;
        //playercs = this.gameObject.GetComponent<Player>();
        // PLHP = playercs.playerHp;
        //PLSP = playercs.playerSp;

        //enemycs = this.gameObject.GetComponent<Enemy>();
        // ENHP = enemycs.enemyHp;
    }

    //UI�}�l�[�W���[�̊Ǌ��̋^���ɂ��A��U�R�����g�A�E�g
    //public void AttackEnemy()
    //{
       // damage = Random.Range(x, y);
        //if(damage > 1)
        //{
            //�G��HP - Damage�̋L�q
            //damage = 0;
        //}
        //Debug.Log(damage);
    //}

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
        //�A�b�v�f�[�g���Ń^�[���̐؂�ւ������Ă͂����Ȃ��ׁA�ʂ�void������ׂ�
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
                //enemycs.AttackPlayer();
            }
        }
    }
}
