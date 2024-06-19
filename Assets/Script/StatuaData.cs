using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Status",menuName = "CreateCharacterStatus")]
public class StatuaData : ScriptableObject
{
    [SerializeField]
    public int Maxhp = 100;
    [SerializeField]
    public int Maxsp = 25;

    public int Hp { get { return Maxhp; } }
    public int Sp { get { return Maxsp; } }
}
