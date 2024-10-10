using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSkillButton : MonoBehaviour
{
    public UIManager UIMG;
    // Start is called before the first frame update
    public void OnClickSkillButton()
    {
        UIMG.PushSkillButton();
    }
}
