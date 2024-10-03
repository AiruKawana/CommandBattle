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

    public GameObject SelectEnemyText;
    [SerializeField] public GameObject SelectEnemybutton1;
    [SerializeField] public GameObject SelectEnemybutton2;

    public bool selectEnemy1;
    public bool selectEnemy2;

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

        MyHP_Text.text = "HP:" + playerHp;
        MySP_Text.text = "SP:" + playerSp;
        EnemyHP_Text.text = "HP:" + enemyHp;

        Item1.SetActive(false);
        Item2.SetActive(false);
        Item3.SetActive(false);
        Item4.SetActive(false);
        Item5.SetActive(false);
        CancelButton.SetActive(false);

        SelectEnemyText.SetActive(false);
        SelectEnemybutton1.SetActive(false);
        SelectEnemybutton2.SetActive(false);

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
        if (damage >= 1)
        {
            enemyHp -= damage;
            Debug.Log("Player�̍U���F" + damage + "�_���[�W");
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
        if(skillCheck == true && damage >= 1)
        {
            if(skillCount == 0)
            {
                skillCheck = false;
                Debug.Log("�X�L�����ʎ��ԏI��");
                Enemyattack();
            }
            else 
            {
                enemyHp -= damage;
                skillCount -= 1;
                Debug.Log("�G�̍U���F" + damage + "�_���[�W�𒵂˕Ԃ���");
                GM.EnemyTurnEnd();
            }
           
        }
        if(skillCheck == false && damage >= 1)
        {
            playerHp -= damage;
            Debug.Log("�G�̍U���F" + damage + "�_���[�W");
            GM.EnemyTurnEnd();
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

    public void PushScelectButton()
    {
        SelectEnemyText.SetActive(false);
        SelectEnemybutton1.SetActive(false);
        SelectEnemybutton2.SetActive(false);


    }

    public void PushSkillButton()
    {
        if(playerSp >= 0 && skillCount == 0)
        {
            skillProbabilityofOccurrence = Random.Range(1, 100);
            if(skillProbabilityofOccurrence <= 20)
            {
                Debug.Log("�X�L�����s");
                GM.PlayerTurnEnd();
            }
            else
            {
                playerSp -= 5;
                skillCheck = true;
                skillCount = 2;
                Debug.Log("�O�^�[���̊ԃX�L������");
                GM.PlayerTurnEnd();
            }

        }
        else
        {
            Debug.Log("�����N���Ȃ�");
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
            Debug.Log("�v���C���[��HP��" + recoveryHp + "�񕜂���");
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
        MyHP_Text2.text = "HP:" + player2Hp;

        MySP_Text.text = "SP:" + playerSp;
        MySP_Text2.text = "SP:" + player2Sp;

        EnemyHP_Text.text = "HP:" + enemyHp;
        EnemyHP_Text2.text = "HP:" + enemy2Hp;

        if (enemyHp < 0 || enemyHp == 0)
        {
            enemyHp = 0;
            GSM.VictoryScene();
        }
        if(playerHp < 0 || playerHp == 0)
        {
            playerHp = 0;
            GSM.LoseScene();
        }
    }
}
 