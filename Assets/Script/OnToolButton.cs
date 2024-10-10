using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnToolButton : MonoBehaviour
{
    public UIManager UIMG;
    // Start is called before the first frame update
    public void OnClickToolButton()
    {
        UIMG.PushToolButton();
    }
}
