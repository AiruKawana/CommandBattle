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
    

    [SerializeField] public int playerHp;
    [SerializeField] public int playerSp;
    [SerializeField] public int enemyHp;

    [SerializeField] public GameObject attackButton;
    [SerializeField] public GameObject skillButton;
    [SerializeField] public GameObject toolButton;
     public TextMeshProUGUI MyHP_Text;
     public TextMeshProUGUI MySP_Text;
     public TextMeshProUGUI EnemyHP_Text;

    [SerializeField] public GameObject Item1;
    [SerializeField] public GameObject Item2;
    [SerializeField] public GameObject Item3;
    [SerializeField] public GameObject Item4;
    [SerializeField] public GameObject Item5;
    [SerializeField] public GameObject CancelButton;

    public int damage;
    private int x = 1;
    private int y = 30;

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

        playerHp = 100;
        playerSp = 25;
        enemyHp = 100;

        MyHP_Text.text = "HP:" + playerHp;
        MySP_Text.text = "SP:" + playerSp;
        EnemyHP_Text.text = "HP:" + enemyHp;

        Item1.SetActive(false);
        Item2.SetActive(false);
        Item3.SetActive(false);
        Item4.SetActive(false);
        Item5.SetActive(false);
        CancelButton.SetActive(false);

        skillCheck = false;
        skillCount = 0;
    }
    public void PlayerTurn()
    {
        attackButton.SetActive(true);
        skillButton.SetActive(true);
        toolButton.SetActive(true);
    }

    public void minusEnemyHp()
    {
        damage = Random.Range(x, y);
        if (damage >= 1)
        {
            enemyHp -= damage;
            Debug.Log("Playerの攻撃：" + damage + "ダメージ");
            GM.PlayerTurnEnd();
        }
    }

    public void EnemyTurn()
    {
        attackButton.SetActive(false);
        skillButton.SetActive(false);
        toolButton.SetActive(false);
    }

    public void minusPlayerHp()
    {
        damage = Random.Range(x, y);
        if(skillCheck == true && damage >= 1)
        {
            if(skillCount == 0)
            {
                skillCheck = false;
                Debug.Log("スキル効果時間終了");
                minusPlayerHp();
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
            playerHp -= damage;
            Debug.Log("敵の攻撃：" + damage + "ダメージ");
            GM.EnemyTurnEnd();
        }
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

        Item1.SetActive(true);
        Item2.SetActive(true);
        Item3.SetActive(true);
        Item4.SetActive(true);
        Item5.SetActive(true);
        CancelButton.SetActive(true);
    }

    public void PushItemButton()
    {
        if(playerHp >= 0 && enemyHp >= 0)
        {
            playerHp += recoveryHp;
            Debug.Log("プレイヤーのHPが" + recoveryHp + "回復した");
            Item1.SetActive(false);
            Item2.SetActive(false);
            Item3.SetActive(false);
            Item4.SetActive(false);
            Item5.SetActive(false);
            CancelButton.SetActive(false);
            GM.PlayerTurnEnd();
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
        MySP_Text.text = "SP:" + playerSp;
        EnemyHP_Text.text = "HP:" + enemyHp;

        if(enemyHp < 0 || enemyHp == 0)
        {
            enemyHp = 0;
            GSM.VictoryScene();
            //勝利画面シーンへの移項
        }
        if(playerHp < 0 || playerHp == 0)
        {
            playerHp = 0;
            GSM.LoseScene();
        }
    }
}
 