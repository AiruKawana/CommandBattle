using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSelectEnemybutton1 : MonoBehaviour
{
    public UIManager UIMG;
    // Start is called before the first frame update
    public void OnSelectEMYbutton1()
    {
        GameObject obj = GameObject.Find("GM");
        UIMG = obj.GetComponent<UIManager>();
        UIMG.selectEnemy1 = true;
        UIMG.PushScelectButton();
        //UIManager‚ÌPushScelectButton‚ÌŒã‚ÌPlayerattack‚Ì•ªŠòˆ—‚Ì’Ç‰Á‚ğŸ‰ñ
    }
}
