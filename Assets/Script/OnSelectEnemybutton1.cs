using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSelectEnemybutton1 : MonoBehaviour
{
    public UIManager UIMG;
    // Start is called before the first frame update
    public void OnSelectEMYbutton1()
    {
        UIMG.PushScelectEnemyButton1();
        //UIManager��PushScelectButton�̌��Playerattack�̕��򏈗��̒ǉ�������
    }
}
