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

    public int damage;
    private int x = 1;
    private int y = 30;
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
        if(damage >= 1)
        {
            playerHp -= damage;
            Debug.Log("敵の攻撃：" + damage + "ダメージ");
            GM.EnemyTurnEnd();
        }
    }

    public void PushToolButton()
    {
        attackButton.SetActive(false);
        skillButton.SetActive(false);
        toolButton.SetActive(false);
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
 