using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] StatusData statusdata;

    [SerializeField] public int enemyHp;
    

    private void Start()
    {
        enemyHp = statusdata.Hp;
    }

    public void AttackPlayer()
    {
        Debug.Log("�v���C���[�ɍU��");
    }
}
