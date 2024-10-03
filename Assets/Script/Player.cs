using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private StatusData statusData;

    [SerializeField] public int playerHp;
    [SerializeField] public int playerSp;
    private int skillCount = 0;
    private int itemCount = 5;

    public int damage;
   // private int x = 1;
    //private int y = 15;
    // Start is called before the first frame update
    void Start()
    {
       //playerHp = statusData.Hp;
       //playerSp = statusData.Sp;
        //MyItem();
    }
   // public void AttackEnemy()
    //{
       // damage = Random.Range(x, y);
        //if (damage > 1)
        //{
            //“G‚ÌHP - Damage‚Ì‹Lq
            //damage = 0;
       // }
        //Debug.Log(damage);
   // }

    public void Skill()
    {
        if(playerSp > skillCount)
        {
            for(int i = 0; i < 3; i++)
            {
                
            }
        }
    }

    public void MyItem()
    {
        if (itemCount > 0)
        {
            --itemCount;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
