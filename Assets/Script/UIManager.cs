using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameManager GM;
    public GameSceneManager GSM;

    [SerializeField] private charadata playercharadata;
    [SerializeField] private charadata player2charadata;
    [SerializeField] private charadata enemycharadata;
    [SerializeField] private charadata enemy2charadata;

    [SerializeField] public int playerHp;
    [SerializeField] public int playerSp;
    [SerializeField] public int enemyHp;

    [SerializeField] public int player2Hp;
    [SerializeField] public int player2Sp;
    [SerializeField] public int enemy2Hp;

    [SerializeField] public GameObject attackButton;
    [SerializeField] public GameObject skillButton;
    [SerializeField] public GameObject toolButton;

     public TextMeshProUGUI MyHP_Text;
     public TextMeshProUGUI MySP_Text;

    public TextMeshProUGUI MyHP_Text2;
    public TextMeshProUGUI MySP_Text2;

    public TextMeshProUGUI EnemyHP_Text;
    public TextMeshProUGUI EnemyHP_Text2;

    [SerializeField] public GameObject Item1;
    [SerializeField] public GameObject Item2;
    [SerializeField] public GameObject Item3;
    [SerializeField] public GameObject Item4;
    [SerializeField] public GameObject Item5;
    [SerializeField] public GameObject CancelButton;

    public GameObject SelectPlayerText;
    [SerializeField] public GameObject SelectPlayerbutton1;
    [SerializeField] public GameObject SelectPlayerbutton2;

    public GameObject SelectEnemyText;
    [SerializeField] public GameObject SelectEnemybutton1;
    [SerializeField] public GameObject SelectEnemybutton2;

    public bool selectPlayer1;
    public bool selectPlayer2;

    public bool selectEnemy1;
    public bool selectEnemy2;

    private int damage;
    private int selectPlayer;
    private int x = 1;
    private int y = 30;
    private int z = 100;

    private int recoveryHp = 15;

    private bool skillCheck;
    private int skillProbabilityofOccurrence;
    private int skillCount;
    // Start is called before the first frame update
    void Start()
    {
        attackButton.SetActive(true);
        skillButton.SetActive(true);
        toolButton.SetActive(true);

        if(playercharadata != null)
        {
            playerHp = playercharadata.MAXHP;
            playerSp = playercharadata.MAXSP;
        }

        if(player2charadata != null)
        {
            player2Hp = player2charadata.MAXHP;
            player2Sp = player2charadata.MAXSP;
        }

        if(enemycharadata != null)
        {
            enemyHp = enemycharadata.MAXHP;
        }

        if(enemy2charadata != null)
        {
            enemy2Hp = enemy2charadata.MAXHP;
        }

        //MyHP_Text.text = "HP:" + playerHp;
        //MySP_Text.text = "SP:" + playerSp;
        //EnemyHP_Text.text = "HP:" + enemyHp;

        Item1.SetActive(false);
        Item2.SetActive(false);
        Item3.SetActive(false);
        Item4.SetActive(false);
        Item5.SetActive(false);
        CancelButton.SetActive(false);

        SelectPlayerText.SetActive(false);
        SelectPlayerbutton1.SetActive(false);
        SelectPlayerbutton2.SetActive(false);

        SelectEnemyText.SetActive(false);
        SelectEnemybutton1.SetActive(false);
        SelectEnemybutton2.SetActive(false);

        selectPlayer1 = false;
        selectPlayer2 = false;
        selectEnemy1 = false;
        selectEnemy2 = false;

        skillCheck = false;
        skillCount = 0;
    }
    public void PlayerTurn()
    {
        attackButton.SetActive(true);
        skillButton.SetActive(true);
        toolButton.SetActive(true);
    }

    public void Playerattack()
    {
        damage = Random.Range(x, y);
        if (damage >= 1 && selectEnemy1 == true)
        {
            enemyHp -= damage;
            Debug.Log("Playerの攻撃：" + damage + "ダメージ");
            selectEnemy1 = false;
            GM.PlayerTurnEnd();
        }
        if (damage >= 1 && selectEnemy2 == true)
        {
            enemy2Hp -= damage;
            Debug.Log("Playerの攻撃：" + damage + "ダメージ");
            selectEnemy2 = false;
            GM.PlayerTurnEnd();
        }
    }

    public void EnemyTurn()
    {
        attackButton.SetActive(false);
        skillButton.SetActive(false);
        toolButton.SetActive(false);
    }

    public void Enemyattack()
    {
        damage = Random.Range(x, y);
        selectPlayer = Random.Range(x, z);
        if (skillCheck == true && damage >= 1)
        {
            if(skillCount == 0)
            {
                skillCheck = false;
                Debug.Log("スキル効果時間終了");
                Enemyattack();
            }
            else 
            {
                enemyHp -= damage;
                skillCount -= 1;
                Debug.Log("敵の攻撃：" + damage + "ダメージを跳ね返した");
                GM.EnemyTurnEnd();
            }
           
        }
        if(skillCheck == false && damage >= 1)
        {
            if(selectPlayer >= 1 && selectPlayer < 49)
            {
                playerHp -= damage;
                Debug.Log("敵の攻撃：" + damage + "ダメージ");
                GM.EnemyTurnEnd();
            }
            if(selectPlayer >= 50)
            {
                player2Hp -= damage;
                Debug.Log("敵の攻撃：" + damage + "ダメージ");
                GM.EnemyTurnEnd();
            }
            
        }
    }

    public void PushAttackButton()
    {
        attackButton.SetActive(false);
        skillButton.SetActive(false);
        toolButton.SetActive(false);

        SelectEnemyText.SetActive(true);
        SelectEnemybutton1.SetActive(true);
        SelectEnemybutton2.SetActive(true);
    }

    public void PushScelectEnemyButton1()
    {
        selectEnemy1 = true;
       SelectEnemyText.SetActive(false);
       SelectEnemybutton1.SetActive(false);
       SelectEnemybutton2.SetActive(false);
       Playerattack();
    }

    public void PushScelectEnemyButton2()
    {
        selectEnemy2 = true;
        SelectEnemyText.SetActive(false);
        SelectEnemybutton1.SetActive(false);
        SelectEnemybutton2.SetActive(false);
        Playerattack();
    }

    public void PushSkillButton()
    {
        if(playerSp >= 0 && skillCount == 0)
        {
            skillProbabilityofOccurrence = Random.Range(1, 100);
            if(skillProbabilityofOccurrence <= 20)
            {
                Debug.Log("スキル失敗");
                GM.PlayerTurnEnd();
            }
            else
            {
                playerSp -= 5;
                skillCheck = true;
                skillCount = 2;
                Debug.Log("三ターンの間スキル発動");
                GM.PlayerTurnEnd();
            }

        }
        else
        {
            Debug.Log("何も起きない");
            GM.PlayerTurnEnd();
        }
    }

    public void PushToolButton()
    {
        attackButton.SetActive(false);
        skillButton.SetActive(false);
        toolButton.SetActive(false);

        SelectPlayerText.SetActive(true);
        SelectPlayerbutton1.SetActive(true);
        SelectPlayerbutton2.SetActive(true);

        //後に書き換え
        //Item1.SetActive(true);
        //Item2.SetActive(true);
        //Item3.SetActive(true);
        //Item4.SetActive(true);
        //Item5.SetActive(true);
        //CancelButton.SetActive(true);
    }

    public void PushSelectPlayerbutton1()
    {
        selectPlayer1 = true;
        SelectPlayerText.SetActive(false);
        SelectPlayerbutton1.SetActive(false);
        SelectPlayerbutton2.SetActive(false);
        Item1.SetActive(true);
        Item2.SetActive(true);
        Item3.SetActive(true);
        Item4.SetActive(true);
        Item5.SetActive(true);
        CancelButton.SetActive(true);
    }

    public void PushSelectPlayerbutton2()
    {
        selectPlayer2 = true;
        SelectPlayerText.SetActive(false);
        SelectPlayerbutton1.SetActive(false);
        SelectPlayerbutton2.SetActive(false);
        Item1.SetActive(true);
        Item2.SetActive(true);
        Item3.SetActive(true);
        Item4.SetActive(true);
        Item5.SetActive(true);
        CancelButton.SetActive(true);
    }

    public void PushItemButton()
    {
        if(selectPlayer1 == true)
        {
            if (playerHp >= 0 && enemyHp >= 0 || enemy2Hp >= 0)
            {
                playerHp += recoveryHp;
                Debug.Log("プレイヤーのHPが" + recoveryHp + "回復した");
                Item1.SetActive(false);
                Item2.SetActive(false);
                Item3.SetActive(false);
                Item4.SetActive(false);
                Item5.SetActive(false);
                CancelButton.SetActive(false);
                selectPlayer1 = false;
                GM.PlayerTurnEnd();
            }
        }
        if(selectPlayer2 == true)
        {
            if (player2Hp >= 0 && enemyHp >= 0 || enemy2Hp >= 0)
            {
                player2Hp += recoveryHp;
                Debug.Log("プレイヤーのHPが" + recoveryHp + "回復した");
                Item1.SetActive(false);
                Item2.SetActive(false);
                Item3.SetActive(false);
                Item4.SetActive(false);
                Item5.SetActive(false);
                CancelButton.SetActive(false);
                selectPlayer2 = false;
                GM.PlayerTurnEnd();
            }
        }
        
    }

    public void PushCancelButton()
    {
        Item1.SetActive(false);
        Item2.SetActive(false);
        Item3.SetActive(false);
        Item4.SetActive(false);
        Item5.SetActive(false);
        CancelButton.SetActive(false);

        PlayerTurn();
    }

    private void Update()
    {
        MyHP_Text.text = "HP:" + playerHp;
        MyHP_Text2.text = "HP:" + player2Hp;

        MySP_Text.text = "SP:" + playerSp;
        MySP_Text2.text = "SP:" + player2Sp;

        EnemyHP_Text.text = "HP:" + enemyHp;
        EnemyHP_Text2.text = "HP:" + enemy2Hp;

        if (enemyHp <= 0 && enemy2Hp <= 0)
        {
            GSM.VictoryScene();
        } else if(enemyHp < 0 || enemyHp == 0)
        {
            enemyHp = 0;
            SelectEnemybutton1.SetActive(false);
        } else if(enemy2Hp < 0 || enemy2Hp == 0)
        {
            enemy2Hp = 0;
            SelectEnemybutton2.SetActive(false);
        }

        if(playerHp <= 0 && player2Hp <= 0)
        {
            playerHp = 0;
            GSM.LoseScene();
        }else if (playerHp < 0 || playerHp == 0)
        {
            playerHp = 0;
            SelectPlayerbutton1.SetActive(false);
        }else if (player2Hp < 0 || player2Hp == 0)
        {
            player2Hp = 0;
            SelectPlayerbutton2.SetActive(false);
        }
    }
}
 