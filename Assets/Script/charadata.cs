using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create StstusData")]
public class charadata : ScriptableObject
{
    public string NAME;
    public int MAXHP;
    public int MAXSP;
    public int SKILLCOUNT;
    public int AITEMCOUNT;
}
