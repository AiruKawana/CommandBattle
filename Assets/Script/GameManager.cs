using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool playerTrue;
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
        playerTrue = true;
        playerMoveCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTrue == true)
        {
            playercs = this.gameObject.GetComponent<Player>();
            PLHP = playercs.playerHp;
            PLSP = playercs.playerSp;
            if(playerMoveCounter == 0)
            {

            }
        }
    }
}
