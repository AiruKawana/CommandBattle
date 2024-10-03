using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // [SerializeField] StatusData statusdata;
    public GameManager GM;
    public UIManager UIMG;

    //[SerializeField] public int enemyHp;

    //[SerializeField] public int playerHp;

    private void Start()
    {
        //enemyHp = GM.ENHP;
        //playerHp = GM.PLHP;
    }

    public void AttackPlayer()
    {
        UIMG.Enemyattack();
      // Debug.Log("ƒvƒŒƒCƒ„[‚ÉUŒ‚");
    }
}
