using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAttackButton : MonoBehaviour
{
    public UIManager UIMG;
    public void OnClickAttackButton()
    {
        UIMG.PushAttackButton();
    }
}
